﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis {
    
    
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
    public partial class invoiceLevel3 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double amountField;
        
        private string cur_insField;
        
        private string descriptionField;
        
        private string tot_insField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public double amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
                this.RaisePropertyChanged("amount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string cur_ins {
            get {
                return this.cur_insField;
            }
            set {
                this.cur_insField = value;
                this.RaisePropertyChanged("cur_ins");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string tot_ins {
            get {
                return this.tot_insField;
            }
            set {
                this.tot_insField = value;
                this.RaisePropertyChanged("tot_ins");
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
    public partial class invoiceLevel2Detail : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double amountField;
        
        private string cur_insField;
        
        private string descriptionField;
        
        private double packageDurationField;
        
        private string tot_insField;
        
        private double totalDurationField;
        
        private string unitField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public double amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
                this.RaisePropertyChanged("amount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string cur_ins {
            get {
                return this.cur_insField;
            }
            set {
                this.cur_insField = value;
                this.RaisePropertyChanged("cur_ins");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public double packageDuration {
            get {
                return this.packageDurationField;
            }
            set {
                this.packageDurationField = value;
                this.RaisePropertyChanged("packageDuration");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string tot_ins {
            get {
                return this.tot_insField;
            }
            set {
                this.tot_insField = value;
                this.RaisePropertyChanged("tot_ins");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public double totalDuration {
            get {
                return this.totalDurationField;
            }
            set {
                this.totalDurationField = value;
                this.RaisePropertyChanged("totalDuration");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string unit {
            get {
                return this.unitField;
            }
            set {
                this.unitField = value;
                this.RaisePropertyChanged("unit");
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
    public partial class invoiceLevel2 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double amountField;
        
        private string descriptionField;
        
        private invoiceLevel2Detail[] detailListField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public double amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
                this.RaisePropertyChanged("amount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("detailList", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=2)]
        public invoiceLevel2Detail[] detailList {
            get {
                return this.detailListField;
            }
            set {
                this.detailListField = value;
                this.RaisePropertyChanged("detailList");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
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
    public partial class invoiceLevel1 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double amountField;
        
        private string descriptionField;
        
        private string idField;
        
        private invoiceItemTypeEnum itemTypeField;
        
        private bool itemTypeFieldSpecified;
        
        private invoiceLevel2[] level2ListField;
        
        private invoiceLevel1Entry[] level2MapField;
        
        private invoiceLevel3[] level3ListField;
        
        private int subLevelSizeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public double amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
                this.RaisePropertyChanged("amount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public invoiceItemTypeEnum itemType {
            get {
                return this.itemTypeField;
            }
            set {
                this.itemTypeField = value;
                this.RaisePropertyChanged("itemType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool itemTypeSpecified {
            get {
                return this.itemTypeFieldSpecified;
            }
            set {
                this.itemTypeFieldSpecified = value;
                this.RaisePropertyChanged("itemTypeSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("level2List", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=4)]
        public invoiceLevel2[] level2List {
            get {
                return this.level2ListField;
            }
            set {
                this.level2ListField = value;
                this.RaisePropertyChanged("level2List");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("entry", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public invoiceLevel1Entry[] level2Map {
            get {
                return this.level2MapField;
            }
            set {
                this.level2MapField = value;
                this.RaisePropertyChanged("level2Map");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("level3List", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=6)]
        public invoiceLevel3[] level3List {
            get {
                return this.level3ListField;
            }
            set {
                this.level3ListField = value;
                this.RaisePropertyChanged("level3List");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public int subLevelSize {
            get {
                return this.subLevelSizeField;
            }
            set {
                this.subLevelSizeField = value;
                this.RaisePropertyChanged("subLevelSize");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://csiws.turkcell.com.tr/")]
    public enum invoiceItemTypeEnum {
        
        /// <remarks/>
        TYPE_1,
        
        /// <remarks/>
        TYPE_2,
        
        /// <remarks/>
        TYPE_3,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://csiws.turkcell.com.tr/")]
    public partial class invoiceLevel1Entry : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyField;
        
        private invoiceLevel2 valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public invoiceLevel2 value {
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
    public partial class GetInvoiceAnalysisListResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private analysisInvoiceLayout returnField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public analysisInvoiceLayout @return {
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
    public partial class analysisInvoiceLayout : operationResult {
        
        private analysisInvoiceLayoutEntry[] graphicMapField;
        
        private bool hasLevel1ID4DesField;
        
        private double invoiceAmountField;
        
        private invoiceLevel1[] level1ListField;
        
        private bool netField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("entry", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public analysisInvoiceLayoutEntry[] graphicMap {
            get {
                return this.graphicMapField;
            }
            set {
                this.graphicMapField = value;
                this.RaisePropertyChanged("graphicMap");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public bool hasLevel1ID4Des {
            get {
                return this.hasLevel1ID4DesField;
            }
            set {
                this.hasLevel1ID4DesField = value;
                this.RaisePropertyChanged("hasLevel1ID4Des");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
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
        [System.Xml.Serialization.XmlElementAttribute("level1List", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=3)]
        public invoiceLevel1[] level1List {
            get {
                return this.level1ListField;
            }
            set {
                this.level1ListField = value;
                this.RaisePropertyChanged("level1List");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public bool net {
            get {
                return this.netField;
            }
            set {
                this.netField = value;
                this.RaisePropertyChanged("net");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://csiws.turkcell.com.tr/")]
    public partial class analysisInvoiceLayoutEntry : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyField;
        
        private double valueField;
        
        private bool valueFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public double value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified {
            get {
                return this.valueFieldSpecified;
            }
            set {
                this.valueFieldSpecified = value;
                this.RaisePropertyChanged("valueSpecified");
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(analysisInvoiceLayout))]
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
    public partial class GetInvoiceAnalysisList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string msisdnField;
        
        private string invoiceDateField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string invoiceDate {
            get {
                return this.invoiceDateField;
            }
            set {
                this.invoiceDateField = value;
                this.RaisePropertyChanged("invoiceDate");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://csiws.turkcell.com.tr/", ConfigurationName="MobileBillAnalysis.MobileBillAnalysis")]
    public interface MobileBillAnalysis {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.Exception), Action="", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GetInvoiceAnalysisListResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GetInvoiceAnalysisList))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(operationResult))]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListResponse1 GetInvoiceAnalysisList(TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListResponse1> GetInvoiceAnalysisListAsync(TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetInvoiceAnalysisList", WrapperNamespace="http://csiws.turkcell.com.tr/", IsWrapped=true)]
    public partial class GetInvoiceAnalysisListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://csiws.turkcell.com.tr/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Msisdn;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://csiws.turkcell.com.tr/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string invoiceDate;
        
        public GetInvoiceAnalysisListRequest() {
        }
        
        public GetInvoiceAnalysisListRequest(string Msisdn, string invoiceDate) {
            this.Msisdn = Msisdn;
            this.invoiceDate = invoiceDate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetInvoiceAnalysisListResponse", WrapperNamespace="http://csiws.turkcell.com.tr/", IsWrapped=true)]
    public partial class GetInvoiceAnalysisListResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://csiws.turkcell.com.tr/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.analysisInvoiceLayout @return;
        
        public GetInvoiceAnalysisListResponse1() {
        }
        
        public GetInvoiceAnalysisListResponse1(TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.analysisInvoiceLayout @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MobileBillAnalysisChannel : TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.MobileBillAnalysis, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MobileBillAnalysisClient : System.ServiceModel.ClientBase<TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.MobileBillAnalysis>, TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.MobileBillAnalysis {
        
        public MobileBillAnalysisClient() {
        }
        
        public MobileBillAnalysisClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MobileBillAnalysisClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileBillAnalysisClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MobileBillAnalysisClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListResponse1 TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.MobileBillAnalysis.GetInvoiceAnalysisList(TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest request) {
            return base.Channel.GetInvoiceAnalysisList(request);
        }
        
        public TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.analysisInvoiceLayout GetInvoiceAnalysisList(string Msisdn, string invoiceDate) {
            TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest inValue = new TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest();
            inValue.Msisdn = Msisdn;
            inValue.invoiceDate = invoiceDate;
            TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListResponse1 retVal = ((TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.MobileBillAnalysis)(this)).GetInvoiceAnalysisList(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListResponse1> TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.MobileBillAnalysis.GetInvoiceAnalysisListAsync(TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest request) {
            return base.Channel.GetInvoiceAnalysisListAsync(request);
        }
        
        public System.Threading.Tasks.Task<TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListResponse1> GetInvoiceAnalysisListAsync(string Msisdn, string invoiceDate) {
            TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest inValue = new TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.GetInvoiceAnalysisListRequest();
            inValue.Msisdn = Msisdn;
            inValue.invoiceDate = invoiceDate;
            return ((TurkcellFacebookDunyasi.ServiceConnector.MobileBillAnalysis.MobileBillAnalysis)(this)).GetInvoiceAnalysisListAsync(inValue);
        }
    }
}
