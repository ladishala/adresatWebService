﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Adresat.Arbk {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Arbk.Sherbimi_ArbkSoap")]
    public interface Sherbimi_ArbkSoap {
        
        // CODEGEN: Generating message contract since element name NrBiznesit from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validoNrBiznesit", ReplyAction="*")]
        Adresat.Arbk.validoNrBiznesitResponse validoNrBiznesit(Adresat.Arbk.validoNrBiznesitRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validoNrBiznesit", ReplyAction="*")]
        System.Threading.Tasks.Task<Adresat.Arbk.validoNrBiznesitResponse> validoNrBiznesitAsync(Adresat.Arbk.validoNrBiznesitRequest request);
        
        // CODEGEN: Generating message contract since element name NrBiznesit from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lexoArbk", ReplyAction="*")]
        Adresat.Arbk.lexoArbkResponse lexoArbk(Adresat.Arbk.lexoArbkRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lexoArbk", ReplyAction="*")]
        System.Threading.Tasks.Task<Adresat.Arbk.lexoArbkResponse> lexoArbkAsync(Adresat.Arbk.lexoArbkRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class validoNrBiznesitRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="validoNrBiznesit", Namespace="http://tempuri.org/", Order=0)]
        public Adresat.Arbk.validoNrBiznesitRequestBody Body;
        
        public validoNrBiznesitRequest() {
        }
        
        public validoNrBiznesitRequest(Adresat.Arbk.validoNrBiznesitRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class validoNrBiznesitRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string NrBiznesit;
        
        public validoNrBiznesitRequestBody() {
        }
        
        public validoNrBiznesitRequestBody(string NrBiznesit) {
            this.NrBiznesit = NrBiznesit;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class validoNrBiznesitResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="validoNrBiznesitResponse", Namespace="http://tempuri.org/", Order=0)]
        public Adresat.Arbk.validoNrBiznesitResponseBody Body;
        
        public validoNrBiznesitResponse() {
        }
        
        public validoNrBiznesitResponse(Adresat.Arbk.validoNrBiznesitResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class validoNrBiznesitResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string validoNrBiznesitResult;
        
        public validoNrBiznesitResponseBody() {
        }
        
        public validoNrBiznesitResponseBody(string validoNrBiznesitResult) {
            this.validoNrBiznesitResult = validoNrBiznesitResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class lexoArbkRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="lexoArbk", Namespace="http://tempuri.org/", Order=0)]
        public Adresat.Arbk.lexoArbkRequestBody Body;
        
        public lexoArbkRequest() {
        }
        
        public lexoArbkRequest(Adresat.Arbk.lexoArbkRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class lexoArbkRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string NrBiznesit;
        
        public lexoArbkRequestBody() {
        }
        
        public lexoArbkRequestBody(string NrBiznesit) {
            this.NrBiznesit = NrBiznesit;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class lexoArbkResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="lexoArbkResponse", Namespace="http://tempuri.org/", Order=0)]
        public Adresat.Arbk.lexoArbkResponseBody Body;
        
        public lexoArbkResponse() {
        }
        
        public lexoArbkResponse(Adresat.Arbk.lexoArbkResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class lexoArbkResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string lexoArbkResult;
        
        public lexoArbkResponseBody() {
        }
        
        public lexoArbkResponseBody(string lexoArbkResult) {
            this.lexoArbkResult = lexoArbkResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Sherbimi_ArbkSoapChannel : Adresat.Arbk.Sherbimi_ArbkSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Sherbimi_ArbkSoapClient : System.ServiceModel.ClientBase<Adresat.Arbk.Sherbimi_ArbkSoap>, Adresat.Arbk.Sherbimi_ArbkSoap {
        
        public Sherbimi_ArbkSoapClient() {
        }
        
        public Sherbimi_ArbkSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Sherbimi_ArbkSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Sherbimi_ArbkSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Sherbimi_ArbkSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Adresat.Arbk.validoNrBiznesitResponse Adresat.Arbk.Sherbimi_ArbkSoap.validoNrBiznesit(Adresat.Arbk.validoNrBiznesitRequest request) {
            return base.Channel.validoNrBiznesit(request);
        }
        
        public string validoNrBiznesit(string NrBiznesit) {
            Adresat.Arbk.validoNrBiznesitRequest inValue = new Adresat.Arbk.validoNrBiznesitRequest();
            inValue.Body = new Adresat.Arbk.validoNrBiznesitRequestBody();
            inValue.Body.NrBiznesit = NrBiznesit;
            Adresat.Arbk.validoNrBiznesitResponse retVal = ((Adresat.Arbk.Sherbimi_ArbkSoap)(this)).validoNrBiznesit(inValue);
            return retVal.Body.validoNrBiznesitResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Adresat.Arbk.validoNrBiznesitResponse> Adresat.Arbk.Sherbimi_ArbkSoap.validoNrBiznesitAsync(Adresat.Arbk.validoNrBiznesitRequest request) {
            return base.Channel.validoNrBiznesitAsync(request);
        }
        
        public System.Threading.Tasks.Task<Adresat.Arbk.validoNrBiznesitResponse> validoNrBiznesitAsync(string NrBiznesit) {
            Adresat.Arbk.validoNrBiznesitRequest inValue = new Adresat.Arbk.validoNrBiznesitRequest();
            inValue.Body = new Adresat.Arbk.validoNrBiznesitRequestBody();
            inValue.Body.NrBiznesit = NrBiznesit;
            return ((Adresat.Arbk.Sherbimi_ArbkSoap)(this)).validoNrBiznesitAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Adresat.Arbk.lexoArbkResponse Adresat.Arbk.Sherbimi_ArbkSoap.lexoArbk(Adresat.Arbk.lexoArbkRequest request) {
            return base.Channel.lexoArbk(request);
        }
        
        public string lexoArbk(string NrBiznesit) {
            Adresat.Arbk.lexoArbkRequest inValue = new Adresat.Arbk.lexoArbkRequest();
            inValue.Body = new Adresat.Arbk.lexoArbkRequestBody();
            inValue.Body.NrBiznesit = NrBiznesit;
            Adresat.Arbk.lexoArbkResponse retVal = ((Adresat.Arbk.Sherbimi_ArbkSoap)(this)).lexoArbk(inValue);
            return retVal.Body.lexoArbkResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Adresat.Arbk.lexoArbkResponse> Adresat.Arbk.Sherbimi_ArbkSoap.lexoArbkAsync(Adresat.Arbk.lexoArbkRequest request) {
            return base.Channel.lexoArbkAsync(request);
        }
        
        public System.Threading.Tasks.Task<Adresat.Arbk.lexoArbkResponse> lexoArbkAsync(string NrBiznesit) {
            Adresat.Arbk.lexoArbkRequest inValue = new Adresat.Arbk.lexoArbkRequest();
            inValue.Body = new Adresat.Arbk.lexoArbkRequestBody();
            inValue.Body.NrBiznesit = NrBiznesit;
            return ((Adresat.Arbk.Sherbimi_ArbkSoap)(this)).lexoArbkAsync(inValue);
        }
    }
}