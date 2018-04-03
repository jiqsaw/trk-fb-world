(function ($, undefined) {
    var kendo = window.kendo,
       escapeQuoteRegExp = /'/ig;

    function parameterMap(options, operation) {
       var result = {};

       if (options.sort) {
           result[this.options.prefix + "sort"] = $.map(options.sort, function(sort) {
               return sort.field + "-" + sort.dir;
           }).join("~");

           delete options.sort;
       } else {
           result[this.options.prefix + "sort"] = "";
       }

       if (options.page) {
           result[this.options.prefix + "page"] = options.page;

           delete options.page;
       }

       if (options.pageSize) {
           result[this.options.prefix + "pageSize"] = options.pageSize;

           delete options.pageSize;
       }

       if (options.group) {
            result[this.options.prefix + "group"] = $.map(options.group, function(group) {
               return group.field + "-" + group.dir;
           }).join("~");

           delete options.group;
       } else {
            result[this.options.prefix + "group"] = "";
       }

       if (options.aggregate) {
           result[this.options.prefix + "aggregate"] =  $.map(options.aggregate, function(aggregate) {
               return aggregate.field + "-" + aggregate.aggregate;
           }).join("~");

           delete options.aggregate;
       }

       if (options.filter) {
           result[this.options.prefix + "filter"] = serializeFilter(options.filter);

           delete options.filter;
       } else {
           result[this.options.prefix + "filter"] = "";
           delete options.filter;
       }

       if (operation != "read" ) {
           if (options.models) {
               var prefix = "models",
                   models = options.models;

               for (var i = 0; i < models.length; i++) {
                   serializeItem(result, models[i], prefix + "[" + i + "].");
               }
           } else if (options) {
               serializeItem(result, options, "");
           }

           delete options.models;
       }

       delete options.take;
       delete options.skip;

       return $.extend(result, options);
    }

    function serializeItem(result, item, prefix) {
        var item = convert(item),
            value,
            key;

        for (var member in item) {
            key = prefix + member;
            value = item[member];

            if ($.isPlainObject(value)) {
                flatten(result, value, key);
            }
            else {
                result[key] = value;
            }
        }
    }

    function convert(values) {
        for (var key in values) {
            var value = values[key];

            if (value instanceof Date) {
                values[key] = kendo.format("{0:G}", value);
            }

            if (typeof value === "number") {
                value = value.toString();
            }

            if (value == undefined) {
                delete values[key];
            }
            if ($.isPlainObject(value)) {
                convert(value);
            }
        }
        return values;
    }

    function flatten(result, value, prefix) {
        for (var key in value) {
            if ($.isPlainObject(value[key])) {
                flatten(result, value[key], prefix ? prefix + "." + key : key);
            } else {
                result[prefix ? prefix + "." + key : key] = value[key];
            }
        }
    }

    function serializeFilter(filter) {
       if (filter.filters) {
           return  $.map(filter.filters, function(f) {
               return serializeFilter(f);
           }).join("~" + filter.logic + "~");
       }
       return filter.field + "~" + filter.operator + "~" + encodeFilterValue(filter.value);
    }

    function encodeFilterValue(value) {
       if (typeof value === "string") {
           if (value.indexOf('Date(') > -1) {
               value = new Date(parseInt(value.replace(/^\/Date\((.*?)\)\/$/, '$1')));
           } else {
               return "'" + value.replace(escapeQuoteRegExp, "''") + "'";
           }
       }

       if (value && value.getTime) {
           return "datetime'" + kendo.format("{0:yyyy-MM-ddTHH-mm-ss}", value) + "'";
       }
       return value;
    }


    function translateGroup(group) {
       return {
           value: group.Key,
           field: group.Member,
           hasSubgroups: group.HasSubgroups,
           aggregates: translateAggregate(group.Aggregates),
           items: group.HasSubgroups ? $.map(group.Items, translateGroup) : group.Items
       };
    }

    function translateAggregateResults(aggregate) {
       var obj = {};
           obj[aggregate.AggregateMethodName.toLowerCase()] = aggregate.Value;

       return obj;
    }

    function translateAggregate(aggregates) {
        var functionResult = {},
            key,
            functionName,
            aggregate;

        for (key in aggregates) {
            functionResult = {};
            aggregate = aggregates[key];

            for (functionName in aggregate) {
               functionResult[functionName.toLowerCase()] = aggregate[functionName];
            }

            aggregates[key] = functionResult;
        }

        return aggregates;
    }

    kendo.data.schemas["aspnetmvc-ajax"] = {
        groups: function(data) {
            return $.map(this.data(data), translateGroup);
        },
        aggregates: function(data) {
            data = data.d || data;
            var result = {},
                aggregates = data.AggregateResults || [],
                aggregate,
                idx,
                length;

            for (idx = 0, length = aggregates.length; idx < length; idx++) {
                aggregate = aggregates[idx];
                result[aggregate.Member] = $.extend(true, result[aggregate.Member], translateAggregateResults(aggregate));
            }
            return result;
        }
    };

    kendo.data.transports["aspnetmvc-ajax"] = kendo.data.RemoteTransport.extend({
        init: function(options) {
            kendo.data.RemoteTransport.fn.init.call(this, $.extend(true, {}, options, this.options));
        },
        read: function(options) {
            var data = this.options.data,
                url = this.options.read.url;
            if (data) {
                if (url) {
                    this.options.data = null;
                }

                if (!data.length && url) {
                    kendo.data.RemoteTransport.fn.read.call(this, options);
                } else {
                    options.success(data);
                }
            } else {
                kendo.data.RemoteTransport.fn.read.call(this, options);
            }
        },
        options: {
            read: {
                type: "POST"
            },
            update: {
                type: "POST"
            },
            create: {
                type: "POST"
            },
            destroy: {
                type: "POST"
            },
            parameterMap: parameterMap,
            prefix: ""
        }
    });

    kendo.data.transports["aspnetmvc-server"] = kendo.data.RemoteTransport.extend({
        init: function(options) {
            kendo.data.RemoteTransport.fn.init.call(this, $.extend(options, { parameterMap: $.proxy(parameterMap, this) } ));
        },
        read: function(options) {
            var url,
                regExp = new RegExp(this.options.prefix + "[^&]*&?", "g"),
                query;

            query = location.search.replace(regExp, "").replace("?", "");
            if (query.length && !(/&$/.test(query))) {
                query += "&";
            }

            options = this.setup(options, "read");
            url = options.url;

            if (url.indexOf("?") >= 0) {
                url += "&" + query;
            } else {
                url += "?" + query;
            }

            url += $.map(options.data, function(value, key) {
                return key + "=" + value;
            }).join("&");

            location.href = url;
        }
    });
})(jQuery);
(function ($, undefined) {
    var nameSpecialCharRegExp = /(\[|\]|\$|\.|\:|\+)/g;

    function generateMessages() {
        var name,
            messages = {};

        for (name in validationRules) {
            messages["mvc" + name] = createMessage(name);
        }
        return messages;
    }

    function generateRules() {
         var name,
             rules = {};

         for (name in validationRules) {
             rules["mvc" + name] = createRule(name);
        }
        return rules;
    }

    function extractParams(input, ruleName) {
        var params = {},
            index,
            data = input.data(),
            length = ruleName.length,
            rule,
            key;

        for (key in data) {
            rule = key.toLowerCase();
            index = rule.indexOf(ruleName);
            if (index > -1) {
                rule = rule.substring(index + length, key.length);
                if (rule) {
                    params[rule] = data[key];
                }
            }
        }
        return params;
    }

    function rulesFromData(metadata) {
        var idx,
            length,
            fields = metadata.Fields || [],
            rules = {};

        for (idx = 0, length = fields.length; idx < length; idx++) {
            $.extend(true, rules, rulesForField(fields[idx]));
        }
        return rules;
    }

    function rulesForField(field) {
        var rules = {},
            messages = {},
            fieldName = field.FieldName,
            fieldRules = field.ValidationRules,
            validationType,
            validationParams,
            idx,
            length;

        for (idx = 0, length = fieldRules.length; idx < length; idx++) {
            validationType = fieldRules[idx].ValidationType;
            validationParams = fieldRules[idx].ValidationParameters;

            rules[fieldName + validationType] = createMetaRule(fieldName, validationType, validationParams);

            messages[fieldName + validationType] = createMetaMessage(fieldRules[idx].ErrorMessage);
        }
        return { rules: rules, messages: messages };
    }

    function createMessage(rule) {
        return function (input) {
            return input.attr("data-val-" + rule);
        };
    }

    function createRule(ruleName) {
        return function (input) {
            if (input.filter("[data-val-" + ruleName + "]").length) {
                return validationRules[ruleName](input, extractParams(input, ruleName));
            }
            return true;
        };
    }

    function createMetaMessage(message) {
        return function() { return message; };
    }

    function createMetaRule(fieldName, type, params) {
        return function (input) {
            if (input.filter("[name=" + fieldName + "]").length) {
                return validationRules[type](input, params);
            }
            return true;
        };
    }

    function patternMatcher(value, pattern) {
        if (typeof pattern === "string") {
            pattern = new RegExp('^(?:' + pattern + ')$');
        }
        return pattern.test(value);
    }

    var validationRules = {
        required: function (input) {
            var value = input.val(),
                checkbox = input.filter("[type=checkbox]");

            if (checkbox.length) {
                var hidden = checkbox.next("input:hidden[name=" + checkbox[0].name + "]");
                if (hidden.length) {
                    value = hidden.val();
                } else {
                    value = input.attr("checked") === "checked";
                }
            }

            return !(value === "" || !value);
        },
        number: function (input) {
            return kendo.parseFloat(input.val()) !== null;
        },
        regex: function (input, params) {
            return patternMatcher(input.val(), params.pattern);
        },
        range: function(input, params) {
            return this.min(input, params) && this.max(input, params);
        },
        min: function(input, params) {
            var min = parseFloat(params.min) || 0,
                val = parseFloat(input.val());

            return min <= val;
        },
        max: function(input, params) {
            var max = parseFloat(params.max) || 0,
                val = parseFloat(input.val());

            return val <= max;
        },
        date: function(input) {
            return kendo.parseDate(input.val()) !== null;
        },
        length: function(input, params) {
            var len = $.trim(input.val()).length;
            return len >= (params.min || 0) && len <= (params.max || 0);
        }
    };

    $.extend(true, kendo.ui.validator, {
        rules: generateRules(),
        messages: generateMessages(),
        messageLocators: {
            mvcLocator: {
                locate: function (element, fieldName) {
                    fieldName = fieldName.replace(nameSpecialCharRegExp, "\\$1");
                    return element.find(".field-validation-valid[data-valmsg-for=" + fieldName + "], .field-validation-error[data-valmsg-for=" + fieldName + "]");
                },
                decorate: function (message, fieldName) {
                    message.addClass("field-validation-error").attr("data-val-msg-for", fieldName || "");
                }
            },
            mvcMetadataLocator: {
                locate: function (element, fieldName) {
                    fieldName = fieldName.replace(nameSpecialCharRegExp, "\\$1");
                    return element.find("#" + fieldName + "_validationMessage.field-validation-valid");
                },
                decorate: function (message, fieldName) {
                    message.addClass("field-validation-error").attr("id", fieldName + "_validationMessage");
                }
            }
        },
        ruleResolvers: {
            mvcMetaDataResolver: {
                resolve: function (element) {
                    var metadata = window.mvcClientValidationMetadata || [];

                    if (metadata.length) {
                        element = $(element);
                        for (var idx = 0; idx < metadata.length; idx++) {
                            if (metadata[idx].FormId == element.attr("id")) {
                                return rulesFromData(metadata[idx]);
                            }
                        }
                    }
                    return {};
                }
            }
        }
    });
})(jQuery);
