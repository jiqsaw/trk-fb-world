﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://csiws.turkcell.com.tr/")]
    public partial class Exception : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://csiws.turkcell.com.tr/")]
    public partial class invoice : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double invoiceAmountField;
        
        private System.DateTime invoiceDateField;
        
        private bool invoiceDateFieldSpecified;
        
        private string invoiceNumberField;
        
        private bool invoiceOpenField;
        
        private long invoiceTypeField;
        
        private bool isPaidField;
        
        private bool notInHobimListField;
        
        private bool notReadyDisplayField;
        
        private System.DateTime paymentLastDateField;
        
        private bool paymentLastDateFieldSpecified;
        
        private string periodField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public double invoiceAmount {
            get {
                return this.invoiceAmountField;
            }
            set {
                this.invoiceAmountField = value;
                this.RaisePropertyChanged("invoiceAmount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public System.DateTime invoiceDate {
            get {
                return this.invoiceDateField;
            }
            set {
                this.invoiceDateField = value;
                this.RaisePropertyChanged("invoiceDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool invoiceDateSpecified {
            get {
                return this.invoiceDateFieldSpecified;
            }
            set {
                this.invoiceDateFieldSpecified = value;
                this.RaisePropertyChanged("invoiceDateSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string invoiceNumber {
            get {
                return this.invoiceNumberField;
            }
            set {
                this.invoiceNumberField = value;
                this.RaisePropertyChanged("invoiceNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public bool invoiceOpen {
            get {
                return this.invoiceOpenField;
            }
            set {
                this.invoiceOpenField = value;
                this.RaisePropertyChanged("invoiceOpen");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public long invoiceType {
            get {
                return this.invoiceTypeField;
            }
            set {
                this.invoiceTypeField = value;
                this.RaisePropertyChanged("invoiceType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public bool isPaid {
            get {
                return this.isPaidField;
            }
            set {
                this.isPaidField = value;
                this.RaisePropertyChanged("isPaid");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public bool notInHobimList {
            get {
                return this.notInHobimListField;
            }
            set {
                this.notInHobimListField = value;
                this.RaisePropertyChanged("notInHobimList");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public bool notReadyDisplay {
            get {
                return this.notReadyDisplayField;
            }
            set {
                this.notReadyDisplayField = value;
                this.RaisePropertyChanged("notReadyDisplay");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public System.DateTime paymentLastDate {
            get {
                return this.paymentLastDateField;
            }
            set {
                this.paymentLastDateField = value;
                this.RaisePropertyChanged("paymentLastDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool paymentLastDateSpecified {
            get {
                return this.paymentLastDateFieldSpecified;
            }
            set {
                this.paymentLastDateFieldSpecified = value;
                this.RaisePropertyChanged("paymentLastDateSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public string period {
            get {
                return this.periodField;
            }
            set {
                this.periodField = value;
                this.RaisePropertyChanged("period");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://csiws.turkcell.com.tr/")]
    public partial class GetInvoceListResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private invoiceList returnField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public invoiceList @return {
            get {
                return this.returnField;
            }
            set {
                this.returnField = value;
                this.RaisePropertyChanged("return");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://csiws.turkcell.com.tr/")]
    public partial class invoiceList : operationResult {
        
        private string coveridField;
        
        private double currentInvoiceAmountField;
        
        private bool hasKtfField;
        
        private invoice[] invoicelistField;
        
        private string ncstField;
        
        private int unPaidInvoiceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string coverid {
            get {
                return this.coveridField;
            }
            set {
                this.coveridField = value;
                this.RaisePropertyChanged("coverid");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public double currentInvoiceAmount {
            get {
                return this.currentInvoiceAmountField;
            }
            set {
                this.currentInvoiceAmountField = value;
                this.RaisePropertyChanged("currentInvoiceAmount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public bool hasKtf {
            get {
                return this.hasKtfField;
            }
            set {
                this.hasKtfField = value;
                this.RaisePropertyChanged("hasKtf");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public invoice[] invoicelist {
            get {
                return this.invoicelistField;
            }
            set {
                this.invoicelistField = value;
                this.RaisePropertyChanged("invoicelist");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string ncst {
            get {
                return this.ncstField;
            }
            set {
                this.ncstField = value;
                this.RaisePropertyChanged("ncst");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public int unPaidInvoice {
            get {
                return this.unPaidInvoiceField;
            }
            set {
                this.unPaidInvoiceField = value;
                this.RaisePropertyChanged("unPaidInvoice");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(invoiceList))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://csiws.turkcell.com.tr/")]
    public partial class operationResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int resultCodeField;
        
        private string resultDescriptionField;
        
        private object valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int resultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
                this.RaisePropertyChanged("resultCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string resultDescription {
            get {
                return this.resultDescriptionField;
            }
            set {
                this.resultDescriptionField = value;
                this.RaisePropertyChanged("resultDescription");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public object value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://csiws.turkcell.com.tr/")]
    public partial class GetInvoceList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string msisdnField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Msisdn {
            get {
                return this.msisdnField;
            }
            set {
                this.msisdnField = value;
                this.RaisePropertyChanged("Msisdn");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://csiws.turkcell.com.tr/", ConfigurationName="MobileBillInfo.MobileBillInfo")]
    public interface MobileBillInfo {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.Exception), Action="", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GetInvoceListResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GetInvoceList))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(operationResult))]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListResponse1 GetInvoceList(TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListResponse1> GetInvoceListAsync(TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetInvoceList", WrapperNamespace="http://csiws.turkcell.com.tr/", IsWrapped=true)]
    public partial class GetInvoceListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://csiws.turkcell.com.tr/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Msisdn;
        
        public GetInvoceListRequest() {
        }
        
        public GetInvoceListRequest(string Msisdn) {
            this.Msisdn = Msisdn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetInvoceListResponse", WrapperNamespace="http://csiws.turkcell.com.tr/", IsWrapped=true)]
    public partial class GetInvoceListResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://csiws.turkcell.com.tr/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.invoiceList @return;
        
        public GetInvoceListResponse1() {
        }
        
        public GetInvoceListResponse1(TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.invoiceList @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MobileBillInfoChannel : TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.MobileBillInfo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MobileBillInfoClient : System.ServiceModel.ClientBase<TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.MobileBillInfo>, TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.MobileBillInfo {
        
        public MobileBillInfoClient() {
        }
        
        public MobileBillInfoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MobileBillInfoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileBillInfoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileBillInfoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListResponse1 TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.MobileBillInfo.GetInvoceList(TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest request) {
            return base.Channel.GetInvoceList(request);
        }
        
        public TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.invoiceList GetInvoceList(string Msisdn) {
            TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest inValue = new TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest();
            inValue.Msisdn = Msisdn;
            TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListResponse1 retVal = ((TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.MobileBillInfo)(this)).GetInvoceList(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListResponse1> TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.MobileBillInfo.GetInvoceListAsync(TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest request) {
            return base.Channel.GetInvoceListAsync(request);
        }
        
        public System.Threading.Tasks.Task<TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListResponse1> GetInvoceListAsync(string Msisdn) {
            TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest inValue = new TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.GetInvoceListRequest();
            inValue.Msisdn = Msisdn;
            return ((TurkcellFacebookDunyasi.ServiceConnector.MobileBillInfo.MobileBillInfo)(this)).GetInvoceListAsync(inValue);
        }
    }
}
