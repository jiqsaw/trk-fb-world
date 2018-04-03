var grid = null;


function generatePeople(itemCount, callback) {
    var data = [],
        delay = 25,
        interval = 500,
        starttime;

    var now = new Date();
    setTimeout(function () {
        starttime = +new Date();
        do {
            var personSought = personSoughts[Math.floor(Math.random() * personSoughts.length)],
            unit = units[Math.floor(Math.random() * units.length)],
            amount = amounts[Math.floor(Math.random() * amounts.length)],
            explanation = explanations[Math.floor(Math.random() * explanations.length)],
            birthDate = birthDates[Math.floor(Math.random() * birthDates.length)],
            fullName = personSoughts[Math.floor(Math.random() * fullNames.length)]

            data.push({
                Id: i + 1,
                PersonSought: personSought,
                Unit: unit,
                Amount: amount,
                Explanation: explanation,
                BirthDate: birthDate,
                FullName: fullName
            });
        } while (data.length < itemCount && +new Date() - starttime < interval);

        if (data.length < itemCount) {
            setTimeout(arguments.callee, delay);
        } else {
            callback(data);
        }
    }, delay);
}