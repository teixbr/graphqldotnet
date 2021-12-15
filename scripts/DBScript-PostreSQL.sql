--
-- PostgreSQL database dump
--

-- Dumped from database version 12.3
-- Dumped by pg_dump version 14.1

-- Started on 2021-12-14 12:34:22 -04

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "BlogsManagement";
--
-- TOC entry 3226 (class 1262 OID 16402)
-- Name: BlogsManagement; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "BlogsManagement" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';


ALTER DATABASE "BlogsManagement" OWNER TO postgres;

\connect "BlogsManagement"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 202 (class 1259 OID 16403)
-- Name: author; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.author (
    id bigint NOT NULL,
    firstname character varying(255) NOT NULL,
    lastname character varying(255) NOT NULL
);


ALTER TABLE public.author OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 16446)
-- Name: authorprize; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.authorprize (
    id bigint NOT NULL,
    authorid bigint NOT NULL,
    prizeid bigint NOT NULL
);


ALTER TABLE public.authorprize OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16411)
-- Name: blogpost; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.blogpost (
    id bigint NOT NULL,
    title character varying(255) NOT NULL,
    authorid bigint NOT NULL
);


ALTER TABLE public.blogpost OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 16421)
-- Name: comment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment (
    id bigint NOT NULL,
    text character varying(255) NOT NULL,
    blogpostid bigint,
    authorid bigint NOT NULL,
    commentid bigint
);


ALTER TABLE public.comment OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16441)
-- Name: prize; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.prize (
    id bigint NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public.prize OWNER TO postgres;

--
-- TOC entry 3216 (class 0 OID 16403)
-- Dependencies: 202
-- Data for Name: author; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.author (id, firstname, lastname) VALUES (1, 'Joydip', 'Kanjilal');
INSERT INTO public.author (id, firstname, lastname) VALUES (2, 'Steve', 'Smith');
INSERT INTO public.author (id, firstname, lastname) VALUES (3, 'Anand', 'Narayanaswamy');


--
-- TOC entry 3220 (class 0 OID 16446)
-- Dependencies: 206
-- Data for Name: authorprize; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.authorprize (id, authorid, prizeid) VALUES (1, 1, 1);
INSERT INTO public.authorprize (id, authorid, prizeid) VALUES (2, 2, 1);
INSERT INTO public.authorprize (id, authorid, prizeid) VALUES (3, 2, 2);


--
-- TOC entry 3217 (class 0 OID 16411)
-- Dependencies: 203
-- Data for Name: blogpost; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.blogpost (id, title, authorid) VALUES (1, 'Introducing C# 10.0', 1);
INSERT INTO public.blogpost (id, title, authorid) VALUES (2, 'Introducing Entity Framework Core', 2);
INSERT INTO public.blogpost (id, title, authorid) VALUES (3, 'Introducing Kubernetes', 1);
INSERT INTO public.blogpost (id, title, authorid) VALUES (4, 'Introducing Machine Learning', 2);
INSERT INTO public.blogpost (id, title, authorid) VALUES (5, 'Introducing DevSecOps', 3);


--
-- TOC entry 3218 (class 0 OID 16421)
-- Dependencies: 204
-- Data for Name: comment; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.comment (id, text, blogpostid, authorid, commentid) VALUES (1, 'First comment!
', NULL, 1, NULL);
INSERT INTO public.comment (id, text, blogpostid, authorid, commentid) VALUES (2, 'Comment of first comment', NULL, 2, 1);


--
-- TOC entry 3219 (class 0 OID 16441)
-- Dependencies: 205
-- Data for Name: prize; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.prize (id, name) VALUES (1, 'Nobel');
INSERT INTO public.prize (id, name) VALUES (2, 'Best Seller');


--
-- TOC entry 3075 (class 2606 OID 16410)
-- Name: author Author_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.author
    ADD CONSTRAINT "Author_pkey" PRIMARY KEY (id);


--
-- TOC entry 3077 (class 2606 OID 16415)
-- Name: blogpost PK_BlogPost; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.blogpost
    ADD CONSTRAINT "PK_BlogPost" PRIMARY KEY (id);


--
-- TOC entry 3083 (class 2606 OID 16450)
-- Name: authorprize author_prize_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.authorprize
    ADD CONSTRAINT author_prize_pkey PRIMARY KEY (id);


--
-- TOC entry 3079 (class 2606 OID 16425)
-- Name: comment comment_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_pkey PRIMARY KEY (id);


--
-- TOC entry 3081 (class 2606 OID 16445)
-- Name: prize role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.prize
    ADD CONSTRAINT role_pkey PRIMARY KEY (id);


--
-- TOC entry 3088 (class 2606 OID 16451)
-- Name: authorprize FK_Author_AuthorPrize; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.authorprize
    ADD CONSTRAINT "FK_Author_AuthorPrize" FOREIGN KEY (authorid) REFERENCES public.author(id) NOT VALID;


--
-- TOC entry 3084 (class 2606 OID 16416)
-- Name: blogpost FK_Author_BlogPost; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.blogpost
    ADD CONSTRAINT "FK_Author_BlogPost" FOREIGN KEY (authorid) REFERENCES public.author(id) NOT VALID;


--
-- TOC entry 3085 (class 2606 OID 16426)
-- Name: comment FK_Author_Comment; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT "FK_Author_Comment" FOREIGN KEY (authorid) REFERENCES public.author(id) NOT VALID;


--
-- TOC entry 3086 (class 2606 OID 16431)
-- Name: comment FK_Comment_Comment; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT "FK_Comment_Comment" FOREIGN KEY (commentid) REFERENCES public.comment(id) NOT VALID;


--
-- TOC entry 3089 (class 2606 OID 16456)
-- Name: authorprize FK_Prize_AuthorPrize; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.authorprize
    ADD CONSTRAINT "FK_Prize_AuthorPrize" FOREIGN KEY (prizeid) REFERENCES public.prize(id) NOT VALID;


--
-- TOC entry 3087 (class 2606 OID 16436)
-- Name: comment Fk_BlogPost_Comment; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT "Fk_BlogPost_Comment" FOREIGN KEY (blogpostid) REFERENCES public.blogpost(id) NOT VALID;


-- Completed on 2021-12-14 12:34:22 -04

--
-- PostgreSQL database dump complete
--

