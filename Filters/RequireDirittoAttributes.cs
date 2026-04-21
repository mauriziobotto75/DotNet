using System.Web.Mvc; 
using PoloFormativo.Mvc.Infrastructure;
public class RequireDirittoAttribute:AuthorizeAttribute
{ 
  string c;
  public RequireDirittoAttribute(string codice)
  {c=codice;}
  protected override bool AuthorizeCore(System.Web.HttpContextBase ctx)
  {return AuthService.HasDiritto(c);} 
  protected override void HandleUnauthorizedRequest(AuthorizationContext f)
  {f.Result=new RedirectResult("/AccessoNegato");}
  }
