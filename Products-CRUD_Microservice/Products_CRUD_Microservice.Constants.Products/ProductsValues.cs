namespace Products_CRUD_Microservice.Constants.Products
{
    public class ProductsValues
    {
        public class Controller
        {
            public const string ROUTE = "api/v{version:apiVersion}/products";
        }

        public class DbContext
        {
            public const string TABLE_NAME = "PRODUCTS";
            public const string PREFIX = "PRD_";

            public class Fields
            {
                public const string ID = ProductsValues.DbContext.PREFIX + "Id";
                public const string NAME = ProductsValues.DbContext.PREFIX + "Name";
                public const string DESCRIPTION = ProductsValues.DbContext.PREFIX + "Description";
                public const string PRICE = ProductsValues.DbContext.PREFIX + "Price";
                public const string CREATED_AT = ProductsValues.DbContext.PREFIX + "CreatedAt";
                public const string UPDATED_AT = ProductsValues.DbContext.PREFIX + "UpdatedAt";
                public const string ENABLED = ProductsValues.DbContext.PREFIX + "Enabled";
            }

            public class FieldsDefaultValues
            {
                public const string CREATED_AT = "GETDATE()";
                public const string UPDATED_AT = "GETDATE()";
            }

            public class FieldsLength
            {
                public const int NAME = 50;
            }

            public class FieldsType
            {
                public const string DESCRIPTION = "TEXT";
                public const string PRICE = "MONEY";
            }

            public class RequiredFields
            {
                public const bool ID = true;
                public const bool NAME = true;
                public const bool DESCRIPTION = false;
                public const bool PRICE = true;
                public const bool CREATED_AT = true;
                public const bool UPDATED_AT = true;
                public const bool ENABLED = true;
            }
        }
    }
}
