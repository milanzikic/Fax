-- Table: korisnicki_nalog

-- DROP TABLE korisnicki_nalog;

CREATE TABLE korisnicki_nalog
(
  "Username" character varying(25),
  "Password" character varying(25),
  "PIN" integer NOT NULL,
  "JMBG" text NOT NULL,
  "Mail" character varying(320),
  "Telefon" character varying(12),
  "Mobilni" character varying(12),
  CONSTRAINT pk_korisnickinalog PRIMARY KEY ("PIN", "JMBG")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE korisnicki_nalog
  OWNER TO postgres;
