﻿namespace Products_CRUD_Microservice.Constants.Products
{
    public class ProductsValues
    {
        public class Api
        {
            public const string DOCUMENTATION_FILE = "ProductsSwaggerDoc.json";
        }

        public class Controller
        {
            public const string ROUTE = "api/v{version:apiVersion}/products";

            public class Actions
            {
                public const string CREATE = "create";
                public const string DELETE = "delete";
                public const string GET_ALL = "getAll";
                public const string GET_BY_ENABLED = "getByEnabled";
                public const string GET_BY_ID = "getById";
                public const string GET_BY_NAME = "getByName";
                public const string UPDATE = "update";
            }
        }

        public class DbContext
        {
            public const string TABLE_NAME = "PRODUCTS";
            public const string PREFIX = "PRD_";
            public const string MIGRATIONS_ASSEMBLY = "Products_CRUD_Microservice.Migrations.Products";

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
