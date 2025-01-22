using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace FamilyRestourant.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string OpenHours { get; set; }
        
        public string Email { get; set; }
        public string Call { get; set; }
    }
}
