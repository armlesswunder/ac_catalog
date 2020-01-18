select "Index", Times from acgc_insect

--select insect with index included in jan_insect table of indecis
select * from insect where "Index" in (select * from jan_insect)

drop table acgc_jan_insect
drop table acgc_feb_insect
drop table acgc_mar_insect 
drop table acgc_apr_insect 
drop table acgc_may_insect 
drop table acgc_jun_insect 
drop table acgc_jul_insect 
drop table acgc_aug1_insect
drop table acgc_aug2_insect 
drop table acgc_sep1_insect 
drop table acgc_sep2_insect
drop table acgc_oct_insect 
drop table acgc_nov_insect 
drop table acgc_dec_insect

--these tables hold the idecis of all insect available in a particular month.
--see the above select statement to see how these elements are useful
create table acgc_jan_insect (id int primary key)
create table acgc_feb_insect (id int primary key)
create table acgc_mar_insect (id int primary key)
create table acgc_apr_insect (id int primary key)
create table acgc_may_insect (id int primary key)
create table acgc_jun_insect (id int primary key)
create table acgc_jul_insect (id int primary key)
create table acgc_aug1_insect (id int primary key)
create table acgc_aug2_insect (id int primary key)
create table acgc_sep1_insect (id int primary key)
create table acgc_sep2_insect (id int primary key)
create table acgc_oct_insect (id int primary key)
create table acgc_nov_insect (id int primary key)
create table acgc_dec_insect (id int primary key)

--insert index of each insect which appears in a given month (or possibly half-month)
insert into acgc_jan_insect values (23), (34), (35), (37), (40)

insert into acgc_feb_insect values (23), (34), (35), (37), (40)

insert into acgc_mar_insect values (23), (34), (35), (1), (2), (17), (18), (22), (37), (40)

insert into acgc_apr_insect values (23), (34), (35), (3), (17), (18), (22), (38), (39), (37)

insert into acgc_may_insect values (23), (34), (35), (10), (17), (18), (22), (36), (38), (39), (37)

insert into acgc_jun_insect values (23), (34), (35), (4), (10), (11), (17), (18), (22), (24), (25), (26), (27), (28), (29), (30),
(31), (32), (33), (36), (38), (39)

insert into acgc_jul_insect values (23), (34), (35), (4), (5), (6), (7), (8), (10), (11), (12), (17), (18), (22), (25), (26), 
(27), (28), (29), (30), (31), (32), (33), (36), (38), (39)
	
insert into acgc_aug1_insect values (23), (34), (35), (4), (5), (6), (7), (8), (11), (12), (14), (19), (20), (22), (25), (26), 
(27), (28), (29), (30), (31), (32), (33), (36), (38), (39)

insert into acgc_aug2_insect values (23), (34), (35), (4), (5), (6), (7), (8), (11), (12), (14), (19), (20), (22), (25), (26), 
(27), (28), (29), (30), (31), (32), (33), (36), (38), (39)

insert into acgc_sep1_insect values (23), (34), (35), (7), (9), (13), (14), (15), (16), (19), (20), (21), (22), (33), (36), (38), 
(39)

insert into acgc_sep2_insect values (23), (34), (35), (7), (9), (13), (14), (15), (16), (19), (20), (21), (22), (33), (36), (38), 
(39)

insert into acgc_oct_insect values (23), (34), (35), (9), (13), (15), (16), (17), (18), (19), (20), (21), (22), (40)

insert into acgc_nov_insect values (23), (34), (35), (13), (22), (37), (40)

insert into acgc_dec_insect values (23), (34), (35), (37), (40)


