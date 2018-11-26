using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using laboratorio_14.Models;

namespace laboratorio_14.Repository
{
    public class AlumnoRepository
    {

        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["Tecsup"].ToString();
            con = new SqlConnection(constr);
        }
        
        public List<AlumnoModel> GetAllAlumnos()
        {
            connection();

            List<AlumnoModel> alumList = new List<AlumnoModel>();
            SqlCommand com = new SqlCommand("GetAlumnos", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            
            foreach (DataRow dr in dt.Rows)
            {
                alumList.Add(new AlumnoModel
                {
                    codalu = Convert.ToString(dr["codalu"]),
                    nomalu = Convert.ToString(dr["nomalu"]),
                    email = Convert.ToString(dr["email"]),
                    telefono = Convert.ToString(dr["telefono"]),
                    codcar = Convert.ToInt32(dr["codcar"]),
                    fecha_ins = Convert.ToDateTime(dr["fecha_ins"]),
                    estado = Convert.ToInt32(dr["estado"]),
                    Fotoalu = Convert.ToString(dr["Fotoalu"])
                });
            }

            return alumList;
        }

        public bool AddAlumno(AlumnoModel obj)
        {
            connection();

            SqlCommand com = new SqlCommand("AddAlumnos", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@codigo", obj.codalu);
            com.Parameters.AddWithValue("@nombre", obj.nomalu);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@telefono", obj.telefono);
            com.Parameters.AddWithValue("@codigo_car", obj.codcar);
            com.Parameters.AddWithValue("@fecha_ins", obj.fecha_ins);
            com.Parameters.AddWithValue("@estado", obj.estado);
            com.Parameters.AddWithValue("@foto", obj.Fotoalu);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAlumno(AlumnoModel obj)
        {
            connection();

            SqlCommand com = new SqlCommand("UpdateAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@codigo", obj.codalu);
            com.Parameters.AddWithValue("@nombre", obj.nomalu);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@telefono", obj.telefono);
            com.Parameters.AddWithValue("@codigo_car", obj.codcar);
            com.Parameters.AddWithValue("@fecha_ins", obj.fecha_ins);
            com.Parameters.AddWithValue("@estado", obj.estado);
            com.Parameters.AddWithValue("@foto", obj.Fotoalu);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAlumno(string id)
        {
            connection();

            SqlCommand com = new SqlCommand("DeleteAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@codigo", id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}