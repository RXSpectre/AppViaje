namespace ProyectoViaje.Models
{
    public class ResponseModel
    {
        private int _codResut;
        private string _msg;

        public int CodResult
        { 
            get { return _codResut; } 
            set { _codResut = value; }
        }

        public string Msg
        { 
            get { return _msg; } 
            set { _msg = value; }
        }

        public ResponseModel()
        {
            this._codResut = 0;
            this._msg = "";
        }
    }
}
