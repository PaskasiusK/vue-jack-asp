PGDMP     0    0    
        	    z            datainputortesting    14.5    14.5     ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    16394    datainputortesting    DATABASE     v   CREATE DATABASE datainputortesting WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
 "   DROP DATABASE datainputortesting;
                postgres    false            ?            1259    16404    komentar    TABLE     ~   CREATE TABLE public.komentar (
    nama character varying(45),
    komentar character varying(45),
    id integer NOT NULL
);
    DROP TABLE public.komentar;
       public         heap    postgres    false            ?            1259    16407    komentar_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.komentar_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.komentar_id_seq;
       public          postgres    false    209            ?           0    0    komentar_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.komentar_id_seq OWNED BY public.komentar.id;
          public          postgres    false    210            \           2604    16408    komentar id    DEFAULT     j   ALTER TABLE ONLY public.komentar ALTER COLUMN id SET DEFAULT nextval('public.komentar_id_seq'::regclass);
 :   ALTER TABLE public.komentar ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    210    209            ?          0    16404    komentar 
   TABLE DATA           6   COPY public.komentar (nama, komentar, id) FROM stdin;
    public          postgres    false    209   ?
       ?           0    0    komentar_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.komentar_id_seq', 2, true);
          public          postgres    false    210            ^           2606    16410    komentar komentar_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.komentar
    ADD CONSTRAINT komentar_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.komentar DROP CONSTRAINT komentar_pkey;
       public            postgres    false    209            ?   )   x??/N,?,-+-K-+!NC????N?D0?4?????? ??     