using System.Text;
using System.Windows.Forms;
using System.IO;






namespace TwitterAwareTokenizer
{
    internal partial class SettingsForm_TwitterAwareTokenizer : Form
    {


        #region Get and Set Options

        public bool preserve_text_case { get; set; }
        public bool reduce_elongation { get; set; }

        #endregion



        public SettingsForm_TwitterAwareTokenizer(bool trimelongation, bool preservecase)
        {
            InitializeComponent();


           LowercaseCheckbox.Checked = !preservecase;
           ReduceElongationCheckbox.Checked = trimelongation;

        }




                                   
        private void OKButton_Click(object sender, System.EventArgs e)
        {

            this.reduce_elongation = ReduceElongationCheckbox.Checked;
            this.preserve_text_case = !LowercaseCheckbox.Checked;
            
            this.DialogResult = DialogResult.OK;

        }
    }
}
