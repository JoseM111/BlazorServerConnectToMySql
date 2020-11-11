using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataLibrary 
{
    public class DataAccess : IDataAccess {
        ///∆ ............. Class Methods .............
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionStr) {
            /* • Connects with our connection string, even if it
                 crashes the connection will close properly everytime */
            
            using IDbConnection connection = new MySqlConnection(connectionStr);
            /* • Rows of type T(Generic|Any)  we do in await to let the conversion
                 from type T to the type being returned & then return it as a List()*/
            // ReSharper disable once SuggestVarOrType_Elsewhere
            IEnumerable<T> rows = await connection.QueryAsync<T>(sql: sql, param: parameters);
            
            return rows.ToList();
        }
        
        public Task SaveData<T>(string sql, T parameters, string connectionStr) {
            /* • Connects with our connection string, even if it
                 crashes the connection will close properly everytime */
            using IDbConnection connection = new MySqlConnection(connectionStr);
            
            /* • Rows of type T(Generic|Any) Returning the Task */
            // ReSharper disable once SuggestVarOrType_Elsewhere
            return connection.ExecuteAsync(sql: sql, param: parameters);
        }
        
        
        
    //∆ ______________________________________________________    
    }// ∆ END DATACLASS
}
