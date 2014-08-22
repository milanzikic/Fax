-- Column: username

-- ALTER TABLE korisnicki_nalog DROP COLUMN username;

ALTER TABLE korisnicki_nalog ADD COLUMN username character varying(25);

-- Column: password

-- ALTER TABLE korisnicki_nalog DROP COLUMN password;

ALTER TABLE korisnicki_nalog ADD COLUMN password character varying(25);

-- Column: pin

-- ALTER TABLE korisnicki_nalog DROP COLUMN pin;

ALTER TABLE korisnicki_nalog ADD COLUMN pin integer;
ALTER TABLE korisnicki_nalog ALTER COLUMN pin SET NOT NULL;

-- Column: jmbg

-- ALTER TABLE korisnicki_nalog DROP COLUMN jmbg;

ALTER TABLE korisnicki_nalog ADD COLUMN jmbg character(13);
ALTER TABLE korisnicki_nalog ALTER COLUMN jmbg SET NOT NULL;

-- Column: mail

-- ALTER TABLE korisnicki_nalog DROP COLUMN mail;

ALTER TABLE korisnicki_nalog ADD COLUMN mail character varying(100);

-- Column: telefon

-- ALTER TABLE korisnicki_nalog DROP COLUMN telefon;

ALTER TABLE korisnicki_nalog ADD COLUMN telefon character varying(30);

-- Column: mobilni

-- ALTER TABLE korisnicki_nalog DROP COLUMN mobilni;

ALTER TABLE korisnicki_nalog ADD COLUMN mobilni character varying(30);