﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Debra_client.UserReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserReference.UserServiceSoap")]
    public interface UserServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CreateUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Debra_client.UserReference.UserResult CreateUser(Debra_client.UserReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CreateUser", ReplyAction="*")]
        System.Threading.Tasks.Task<Debra_client.UserReference.UserResult> CreateUserAsync(Debra_client.UserReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UserLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Debra_client.UserReference.User UserLogin(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UserLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<Debra_client.UserReference.User> UserLoginAsync(string email, string password);
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Employee))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Customer))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Partner))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class User : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int useridField;
        
        private string emailField;
        
        private string passwordField;
        
        private string userTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Userid {
            get {
                return this.useridField;
            }
            set {
                this.useridField = value;
                this.RaisePropertyChanged("Userid");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("Email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string UserType {
            get {
                return this.userTypeField;
            }
            set {
                this.userTypeField = value;
                this.RaisePropertyChanged("UserType");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class UserResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool successField;
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
                this.RaisePropertyChanged("Success");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("Message");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Employee : User {
        
        private int employeeIDField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private string roleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int EmployeeID {
            get {
                return this.employeeIDField;
            }
            set {
                this.employeeIDField = value;
                this.RaisePropertyChanged("EmployeeID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
                this.RaisePropertyChanged("FirstName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
                this.RaisePropertyChanged("LastName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
                this.RaisePropertyChanged("Role");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Customer : User {
        
        private int customerIDField;
        
        private string firstnameField;
        
        private string lastnameField;
        
        private string phoneField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int CustomerID {
            get {
                return this.customerIDField;
            }
            set {
                this.customerIDField = value;
                this.RaisePropertyChanged("CustomerID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Firstname {
            get {
                return this.firstnameField;
            }
            set {
                this.firstnameField = value;
                this.RaisePropertyChanged("Firstname");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Lastname {
            get {
                return this.lastnameField;
            }
            set {
                this.lastnameField = value;
                this.RaisePropertyChanged("Lastname");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
                this.RaisePropertyChanged("Phone");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Partner : User {
        
        private int partnterIDField;
        
        private string companyNameField;
        
        private bool isActiveField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int PartnterID {
            get {
                return this.partnterIDField;
            }
            set {
                this.partnterIDField = value;
                this.RaisePropertyChanged("PartnterID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
                this.RaisePropertyChanged("CompanyName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool IsActive {
            get {
                return this.isActiveField;
            }
            set {
                this.isActiveField = value;
                this.RaisePropertyChanged("IsActive");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UserServiceSoapChannel : Debra_client.UserReference.UserServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceSoapClient : System.ServiceModel.ClientBase<Debra_client.UserReference.UserServiceSoap>, Debra_client.UserReference.UserServiceSoap {
        
        public UserServiceSoapClient() {
        }
        
        public UserServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Debra_client.UserReference.UserResult CreateUser(Debra_client.UserReference.User user) {
            return base.Channel.CreateUser(user);
        }
        
        public System.Threading.Tasks.Task<Debra_client.UserReference.UserResult> CreateUserAsync(Debra_client.UserReference.User user) {
            return base.Channel.CreateUserAsync(user);
        }
        
        public Debra_client.UserReference.User UserLogin(string email, string password) {
            return base.Channel.UserLogin(email, password);
        }
        
        public System.Threading.Tasks.Task<Debra_client.UserReference.User> UserLoginAsync(string email, string password) {
            return base.Channel.UserLoginAsync(email, password);
        }
    }
}
