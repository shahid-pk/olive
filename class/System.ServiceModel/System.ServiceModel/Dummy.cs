using System.ServiceModel.Channels;

namespace System.IO
{
	public class PipeException : Exception { }
}

namespace System.ServiceModel
{
	public class NamedPipeTransportSecurity { }
	public class NetNamedPipeBinding : Binding { public override BindingElementCollection CreateBindingElements () { throw new NotImplementedException (); }  public override string Scheme { get { return null; } } }
	public class NetNamedPipeSecurity { }
	public class PeerHopCountAttribute { }
	public class TransactionFlowAttribute { }
}

namespace System.ServiceModel.Activation.Configuration
{
	public class Dummy { }
}

namespace System.ServiceModel.Channels
{
	public class PeerCustomResolverBindingElement { }
	public class PrivacyNoticeBindingElement { }
	public class PrivacyNoticeBindingElementImporter { }
	public class ReliableSessionBindingElement { }
	public class UseManagedPresentationBindingElementImporter { }
	public class XmlSerializerImportOptions { }
}

namespace System.ServiceModel.MsmqIntegration
{
	public class MsmqIntegrationBinding : MsmqBindingBase { public override BindingElementCollection CreateBindingElements () { throw new NotImplementedException ();} public override string Scheme { get { return "msmq.formatname"; } } }
	public class MsmqIntegrationBindingElement { }
	public class MsmqIntegrationSecurity { }
}

namespace System.ServiceModel.PeerResolvers
{
        //public interface IPeerResolverContract {}
        //public class CustomPeerResolverService {}
	public class PeerCustomResolverSettings {}
	public class PeerResolverSettings {}
}
