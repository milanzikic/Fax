-- Table: korisnicki_nalog

-- DROP TABLE korisnicki_nalog;

CREATE TABLE korisnicki_nalog
(
  username character varying(25),
  password character varying(25),
  pin integer NOT NULL,
  jmbg character(13) NOT NULL,
  mail character varying(100),
  telefon character varying(30),
  mobilni character varying(30),
  CONSTRAINT pk_korisnickinalog PRIMARY KEY (pin, jmbg)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE korisnicki_nalog
  OWNER TO postgres;