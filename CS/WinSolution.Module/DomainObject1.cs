using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session) : base(session) { }
    }
}
