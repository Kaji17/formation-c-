namespace TP2
{
    public static class MethodExtension
    {
        public static string CheckSqlInjection(this string variable)
        {
            string resultat = "La chaine de caratère ne contient pas du code d'injection SQL";
            if (string.IsNullOrEmpty(variable))
            {
                return "La chaine de caratère est vide";
            }

            string[] keyWordSql = 
            {
                "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "ALTER", "EXEC", "UNION", 
                "OR", "AND", "WHERE", "--", ";", "/*", "*/", "@@", "CHAR(", "NCHAR(", 
                "VARCHAR(", "NVARCHAR(", "CAST(", "CONVERT(", "XP_"
            };

            foreach (string key in keyWordSql)
            {
                if (variable.ToUpper().Contains(key.ToUpper()))
                {
                    return "La chaine de caratère contient du code d'injection sql";
                }
            }
            
            return resultat;
        }
    }
}
