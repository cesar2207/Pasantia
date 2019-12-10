using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace ServicioMonteCacao
{
    public class ConexionBD{

        string cadena = "Data Source=DESKTOP-GNOJF0Q\\SQLEXPRESS;Initial Catalog=MONTECACAO;Integrated Security=true";
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader dr;      
        
        public ConexionBD(){
            try
            {
                conexion = new SqlConnection(cadena);
                conexion.Open();
                Console.WriteLine("Conectado");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: "+ex.ToString());
            }        
        }

        
        public void cerrar(){
            conexion.Close();
        }
        public List<Producto> listarProductos(){
            List<Producto> productos = new List<Producto>();
            byte[] img2;
            try{
                comando = new SqlCommand("SELECT P.CodProd,P.Descrip,P.Descrip2,P.Descrip3,P.Precio1,I.Imagen FROM dbo.SAPROD AS P LEFT JOIN dbo.SAIPRD AS I ON P.CodProd=I.CodProd",conexion);
                dr = comando.ExecuteReader();
                while (dr.Read()){
                    Producto pr = new Producto();
                    pr.codigo = dr["CodProd"].ToString();
                    pr.nombre = dr["Descrip"].ToString();
                    pr.precio = Double.Parse(dr["Precio1"].ToString());
                    if (!Convert.IsDBNull(dr["Imagen"])){
                        img2 = (byte[])dr["Imagen"];
                        pr.img1 = Convert.ToBase64String(img2);

                    }
                                                          
                    pr.descripcion =dr["Descrip2"].ToString()+dr["Descrip3"].ToString();
                    productos.Add(pr);
                }
                
            }
            catch(SqlException ex){
                Console.WriteLine("Error: "+ex.ToString());
            }

            return productos;
        }

        public bool existeClienteId(string id){
            bool existe= false;
            int i=0;
            try{
                comando = new SqlCommand("SELECT CodClie FROM dbo.SACLIE WHERE ID3 ='"+ id+"'");
                dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    i++;
                } 
                if (i==0){
                    existe =false;
                }
                else{
                    existe=true;
                }
            }
            catch(SqlException ex){
                Console.WriteLine("Error: "+ex.ToString());
            }
            return existe;
        }
        public bool existeClienteCorreo(string correo){
            bool existe = false;
            int i=0;
            try{
                comando = new SqlCommand("SELECT CodClie FROM dbo.SACLIE WHERE ID3 ='"+ correo+"'");
                dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    i++;
                } 
                if (i==0){
                    existe =false;
                }
                else{
                    existe=true;
                }
            }
            catch(SqlException ex){
                Console.WriteLine("Error: "+ex.ToString());
            }
            return existe;
        }
        public bool existeClienteIdCorreo(string id,string correo){
            bool existe = false;
            int i=0;
            try{
                comando = new SqlCommand("SELECT CodClie,Email FROM dbo.SACLIE WHERE ID3 ='"+ id+"'" );
                dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    i++;
                } 
                if (i==0){
                    existe =false;
                }
                else{
                    existe=true;
                }
            }
            catch(SqlException ex){
                Console.WriteLine("Error: "+ex.ToString());
            }
            return existe;
            
        }

    }
    
}