CREATE TABLE IF NOT EXISTS public.jobs
(
    id bigint NOT NULL DEFAULT nextval('jobs_id_seq'::regclass),
    name character varying(128) COLLATE pg_catalog."default" NOT NULL,
    description character varying(512) COLLATE pg_catalog."default",
    active boolean,
    status integer,
    crontab character varying(128) COLLATE pg_catalog."default" NOT NULL,
    last_execution timestamp with time zone,
    next_execution timestamp with time zone,
    CONSTRAINT jobs_pkey PRIMARY KEY (id)
);

INSERT INTO public.jobs 
    (name, description, active, status, crontab, next_execution) 
VALUES 
    ('GetTickers', '-', true, 0, '00 20 * * *', '2022-06-06 16:00:00');

CREATE TABLE IF NOT EXISTS public.tickers
(
    id bigint NOT NULL DEFAULT nextval('tickers_id_seq'::regclass),
    ticker character varying(16) COLLATE pg_catalog."default" NOT NULL,
    fullname character varying(128) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT tickers_pkey PRIMARY KEY (id)
);