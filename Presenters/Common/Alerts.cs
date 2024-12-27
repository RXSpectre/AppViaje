using System.Windows.Forms;

namespace ProyectoViaje.Presenters.Common
{
    public static class Alerts
    {
        public static void BuilAlerts(string body, MessageBoxIcon iconic)
        {
            string title = "";

            if (iconic.Equals(MessageBoxIcon.Error))
                title = "Errores";
            else if (iconic.Equals(MessageBoxIcon.Information))
                title = "Información";
            else if (iconic.Equals(MessageBoxIcon.Warning))
                title = "Advertencia";

            MessageBox.Show(body, title, MessageBoxButtons.OK, iconic);
        }


        public static bool BuilAlertsQuestion(string body)
        {
            DialogResult result=MessageBox.Show(body, "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

    }
}
