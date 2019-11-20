
CREATE DATABASE "SupplyOfProducts"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Spain.1252'
    LC_CTYPE = 'Spanish_Spain.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;


CREATE ROLE user1 WITH
  LOGIN
  SUPERUSER
  INHERIT
  CREATEDB
  CREATEROLE
  NOREPLICATION;

GRANT postgres TO user1 WITH ADMIN OPTION;

COMMENT ON ROLE user1 IS 'user1';


CREATE TABLE public."Worker"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Code" text COLLATE pg_catalog."default" NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Birthday" date,
    "City" text COLLATE pg_catalog."default",
    "Country" text COLLATE pg_catalog."default",
    "Street" text COLLATE pg_catalog."default",
    CONSTRAINT worker_pkey PRIMARY KEY ("Id")
);

ALTER TABLE public."Worker"
    OWNER to postgres;
	
CREATE TABLE public."Product"(
	"Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
	"Type" text NOT NULL,
	"Code" text NOT NULL,
	"Class" text NOT NULL ,
	CONSTRAINT product_pkey PRIMARY KEY ("Id")
);

ALTER TABLE public."Product"
    OWNER to postgres;

CREATE TABLE public."WorkPlace"(
	"Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
	"Code" text NOT NULL,
	CONSTRAINT workPlace_pkey PRIMARY KEY ("Id")
);

ALTER TABLE public."WorkPlace"
    OWNER to postgres;

CREATE TABLE public."WorkerInWorkPlace"(
	"Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
	"WorkerId" integer NOT NULL REFERENCES "Worker"("Id") ON DELETE RESTRICT,
	"WorkPlaceId" integer NOT NULL REFERENCES "WorkPlace"("Id") ON DELETE RESTRICT,
	"DateStart" timestamp NOT NULL,
	"DateEnd" timestamp NULL,
	"NumYearsByPeriod" integer NULL,
  CONSTRAINT "WorkerInWorkPlace_pkey" PRIMARY KEY ("Id")
);

ALTER TABLE public."WorkerInWorkPlace"
    OWNER to postgres;

CREATE TABLE public."ConfigSupply"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Date" timestamp without time zone NOT NULL,
    "PeriodDate" timestamp without time zone NOT NULL,
    "WorkerInWorkPlaceId" integer NOT NULL REFERENCES "WorkerInWorkPlace"("Id") ON DELETE RESTRICT,
    "ProductId" integer NOT NULL,
    "SupplyScheduledId" integer NOT NULL,
    "Amount" integer NOT NULL,
  CONSTRAINT configsupply_pkey PRIMARY KEY ("Id")
);

ALTER TABLE public."ConfigSupply"
    OWNER to postgres;

CREATE TABLE public."ProductParts"(
	"ProductId" integer NOT NULL REFERENCES "Product"("Id") ON DELETE RESTRICT,
	"ParentProductId" integer NOT NULL REFERENCES "Product"("Id") ON DELETE RESTRICT,
   PRIMARY KEY ("ProductId","ParentProductId" ));

ALTER TABLE public."ProductParts"
    OWNER to postgres;
   
CREATE TABLE public."ProductStock"(
	"Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
	"ProductId" integer NOT NULL REFERENCES "Product"("Id") ON DELETE RESTRICT,
	"PartNumber" text NOT NULL,
	"BookingId" integer NULL,
 CONSTRAINT productStock_pkey PRIMARY KEY ("Id")
);

ALTER TABLE public."ProductStock"
    OWNER to postgres;
 
 CREATE TABLE public."ProductSupplied"(
	"Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
	"ProductSupplyId" integer NOT NULL,
	"ProductStockId" integer NOT NULL REFERENCES "ProductStock"("Id") ON DELETE RESTRICT,
	"ParentProductSuppliedId" integer NULL,
	CONSTRAINT productSupplied_pkey PRIMARY KEY ("Id")
);

ALTER TABLE public."ProductSupplied"
    OWNER to postgres;
	 
CREATE TABLE public."ProductSupply"(
	"Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
	"WorkerInWorkPlaceId" integer NOT NULL REFERENCES "WorkerInWorkPlace"("Id") ON DELETE RESTRICT,
	"ProductId" integer NOT NULL REFERENCES "Product"("Id") ON DELETE RESTRICT,
	"Date" timestamp NOT NULL,
	"PeriodDate" timestamp NOT NULL,
	CONSTRAINT ProductSupply_pkey PRIMARY KEY ("Id")
);
 
ALTER TABLE public."ProductSupply"
    OWNER to postgres;
	 
 CREATE TABLE public."SupplyScheduled"(
	"Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
	"PeriodDate" timestamp NOT NULL,
	"WorkerInWorkPlaceId" integer NOT NULL REFERENCES "WorkerInWorkPlace"("Id") ON DELETE RESTRICT,
	"ProductId" integer NOT NULL REFERENCES "Product"("Id") ON DELETE RESTRICT,
	"Amount" integer NOT NULL,
	CONSTRAINT SupplyScheduled_pkey PRIMARY KEY ("Id")
);
 	
ALTER TABLE public."SupplyScheduled"
    OWNER to postgres;