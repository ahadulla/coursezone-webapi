CREATE TABLE users
(
    id bigint generated always as identity primary key NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50),
    email text,
    phone_number character varying(15),
    balance real,
    avatar_path text,
    password_hash text,
    salt text,
    created_at timestamp without time zone default now(),
    updated_at timestamp without time zone default now(),
    is_delated boolean
);

CREATE TABLE course_type
(
    id bigint generated always as identity primary key NOT NULL,
    name character varying(50),
    description text,
    video_path text,
    created_at timestamp without time zone default now(),
    updated_at timestamp without time zone default now()
);

CREATE TABLE course
(
    id bigint generated always as identity primary key NOT NULL,
	type integer,
    user_id bigint references users(id),
    course_type_id bigint references course_type(id),
    name text,
    price real,
    description text,
    image_path text,
    created_at timestamp without time zone default now(),
    updated_at timestamp without time zone default now()
);

CREATE TABLE stars
(
    id bigint generated always as identity primary key NOT NULL,
    user_id bigint references users(id),
    course_id bigint references course(id),
    star integer
);

CREATE TABLE videos
(
    id bigint generated always as identity primary key NOT NULL,
    course_id bigint references course(id),
    description text,
    video_path text,
    created_at timestamp without time zone default now(),
    updated_at timestamp without time zone default now()
);

CREATE TABLE orders
(
    id bigint generated always as identity primary key NOT NULL,
    user_id bigint references users(id),
    course_id bigint references course(id),
    create_at timestamp without time zone default now()
);

CREATE TABLE coursezone_point
(
    id bigint generated always as identity primary key NOT NULL,
    order_id bigint references orders(id),
    price real,
    create_at timestamp without time zone default now()
);

