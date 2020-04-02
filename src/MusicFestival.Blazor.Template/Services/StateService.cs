using MusicFestival.Blazor.Template.ViewModels;
using System;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Services
{
    public class StateService 
    {        
        public event Func<Task> Notify;

        private bool _modalShowing;

        public bool ModalShowing
        {
            get
            {
                return _modalShowing;
            }
            set
            {
                _modalShowing = value;
                Notify.Invoke();
            }
        }
        public bool IsEditable { get; set; }
        public bool IsInEditMode { get; set; }
        public bool EpiDisableEditing => ModalShowing;

        public LanguageViewModel CurrentLanguage { get; set; }

        public string EnableEditProperty(string propertyName)
        {
            if (IsInEditMode && !EpiDisableEditing)
                return propertyName;

            // When an attribute value is null, it will not
            // be rendered by Blazor.
            return null;            
        }
        
        public PageBaseViewModel CurrentViewModel {get;set;}
        


    }
}
