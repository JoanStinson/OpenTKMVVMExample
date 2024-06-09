using System.ComponentModel;
using OpenTK_controls_firstperson.View;
using OpenTK_controls_firstperson.Model;
using OpenTK_libray_viewmodel.Control;
using OpenTK.Wpf;

/// <summary>
/// [opentk/GLWpfControl](https://github.com/opentk/GLWpfControl)
/// </summary>

namespace OpenTK_controls_firstperson.ViewModel
{
    class OpenTK_ViewModel
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private OpenTK_View _form;
        private GLWpfControl _glc;
        private GLWpfControlViewModel _glc_vm;
        private Scene_Model _gl_model = new Scene_Model();

        public OpenTK_ViewModel()
        { }

        public OpenTK_View Form
        {
            get { return _form; }
            set
            {
                _form = value;
                _glc = _form.gl_control;
                _glc_vm = new GLWpfControlViewModel(_glc, _gl_model);
            }
        }

        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}

