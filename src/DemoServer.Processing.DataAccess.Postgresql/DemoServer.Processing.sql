SET check_function_bodies = false
;

CREATE SEQUENCE Sequence_ChangeTracker START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE Sequence_SystemLog START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE Sequence_TablePartition START WITH 1 INCREMENT BY 1;

CREATE TABLE changetracker
  (id bigint NOT NULL, CONSTRAINT "Primary key changetracker" PRIMARY KEY(id))
  PARTITION BY RANGE (id);

CREATE TABLE demoobject(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamp NOT NULL,
  modificationdate timestamp NOT NULL,
  "name" character varying(1024) NOT NULL,
  enabled boolean NOT NULL,
  CONSTRAINT "Primary key demoobject" PRIMARY KEY(id)
) PARTITION BY RANGE (id);

CREATE TABLE demoobjectx(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamptz NOT NULL,
  modificationdate timestamptz NOT NULL,
  "name" character varying(1024) NOT NULL,
  enabled boolean NOT NULL,
  key1 uuid NOT NULL,
  key2 character varying(10) NOT NULL,
  "group" bigint NOT NULL,
  CONSTRAINT demoobjectx_pkey PRIMARY KEY(id)
);

  CREATE UNIQUE INDEX demoobjectx_key_u_idx ON demoobjectx(key1, key2);
  
  CREATE INDEX demoobjectx_group_idx ON demoobjectx("group");
  
CREATE TABLE demodelaytask(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamptz NOT NULL,
  modificationdate timestamptz NOT NULL,
  available boolean NOT NULL,
  startdate timestamptz,
  scenario text NOT NULL,
  scenariostate text NOT NULL,
  CONSTRAINT gw_incomingcallbackеtask_pkey PRIMARY KEY(id)
) PARTITION BY RANGE (id);

CREATE TABLE systemlog(
  id bigint NOT NULL,
  createdate timestamptz NOT NULL,
  code integer NOT NULL,
  "type" integer NOT NULL,
  message character varying(1024) NOT NULL,
  "data" text NOT NULL,
  CONSTRAINT "Primary key systemlog" PRIMARY KEY(id)
) PARTITION BY RANGE (id);

CREATE TABLE systemsetting(
  id uuid NOT NULL,
  "value" text NOT NULL,
  "name" character varying(1024) NOT NULL,
  CONSTRAINT "Primary key systemsetting" PRIMARY KEY(id)
);

INSERT INTO SystemSetting (Id, Value, Name) VALUES('CF0ED582-05EC-4AFE-883F-1D68A751B4A8', '9F8FD1D7-8D62-4B73-8A43-9E42518A4A57', 'Код продукта')
;

INSERT INTO SystemSetting (Id, Value, Name) VALUES('1BF69D7C-2CBF-45a8-9526-0C33234ED62D', '1.0.0', 'Версия продукта')
;

INSERT INTO SystemSetting (Id, Value, Name) VALUES('208B4E39-A3D1-45E2-A9DC-E79B3E064DF1', 'Полнофункциональный демонстрационный сервер на базе библиотеки Wattle', 'Имя инсталляции')
;


CREATE TABLE tablepartition(
  id bigint NOT NULL,
  createdate timestamptz NOT NULL,
  tablename character varying NOT NULL,
  partitionname character varying NOT NULL,
  "day" date NOT NULL,
  mingroupid bigint NOT NULL,
  maxnotincludegroupid bigint NOT NULL,
  minid bigint NOT NULL,
  maxnotincludeid bigint NOT NULL,
  CONSTRAINT "Primary key tablepartition" PRIMARY KEY(id)
) PARTITION BY RANGE (id);

CREATE SEQUENCE Sequence_DemoDelayTask START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE Sequence_DemoObject START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE Sequence_DemoObjectX START WITH 1 INCREMENT BY 1;
