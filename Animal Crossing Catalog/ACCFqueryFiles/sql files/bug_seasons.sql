select * from insect

--select insect with index included in jan_insect table of indecis
select * from insect where "Index" in (select * from jan_insect)

drop table jan_insect
drop table feb_insect
drop table mar_insect 
drop table apr_insect 
drop table may_insect 
drop table jun_insect 
drop table jul_insect 
drop table aug1_insect
drop table aug2_insect 
drop table sep1_insect 
drop table sep2_insect
drop table oct_insect 
drop table nov_insect 
drop table dec_insect

--these tables hold the idecis of all insect available in a particular month.
--see the above select statement to see how these elements are useful
create table jan_insect (id int primary key)
create table feb_insect (id int primary key)
create table mar_insect (id int primary key)
create table apr_insect (id int primary key)
create table may_insect (id int primary key)
create table jun_insect (id int primary key)
create table jul_insect (id int primary key)
create table aug1_insect (id int primary key)
create table aug2_insect (id int primary key)
create table sep1_insect (id int primary key)
create table sep2_insect (id int primary key)
create table oct_insect (id int primary key)
create table nov_insect (id int primary key)
create table dec_insect (id int primary key)

--insert index of each insect which appears in a given month (or possibly half-month)
insert into jan_insect values (13), (27), (58), (60), (34), (37), (41), (61)

insert into feb_insect values (13), (27), (58), (60), (34), (37), (41), (61)

insert into mar_insect values (13), (27), (58), (60), (1), (2), (3), (4), (12), (34), (38), 
	(57), (62)

insert into apr_insect values (13), (27), (58), (60), (1), (2), (3), (4), (12), (16), (17),
	(30), (34), (38), (57), (62)

insert into may_insect values (13), (27), (58), (60), (1), (2), (3), (4), (8), (10), (12),
	(14), (16), (17), (28), (29), (30), (34), (38), (57), (62)

insert into jun_insect values (13), (27), (58), (60), (1), (2), (3), (4), (6), (7), (8), 
	(9), (10), (11), (12), (14), (16), (17), (22), (24), (28), (29), (30), (38), (39), (42), 
	(57), (59), (61), (62), (63)

insert into jul_insect values (13), (27), (58), (60), (6), (7), (3), (4), (8), (9), (10), 
	(11), (14), (16), (17), (18), (19), (20), (21), (22), (24), (25), (28), (29), (30), 
	(33), (35), (36),(40), (43), (44), (45), (46), (47), (48), (50), (51), (52), (53), 
	(54), (55), (49), (56), (57), (59), (61), (62), (63), (64)
	
insert into aug1_insect values (13), (27), (58), (60), (3), (4), (6), (7), (8), (9), (10), 
	(11), (14), (15), (16), (17), (18), (19), (20), (21), (22), (24), (25), (26), (28), (29), 
	(30), (33), (35), (36),(40), (43), (44), (45), (46), (47), (48), (50), (51), (52), (53), 
	(54), (55), (49), (56), (57), (59), (61), (62), (63), (64) 

insert into aug2_insect values (13), (27), (58), (60), (3), (4), (6), (7), (8), (9), (10), 
	(11), (14), (15), (16), (17), (18), (19), (20), (21), (22), (24), (25), (26), (28), (29),
	(30), (33), (35), (36),(40), (43), (44), (45), (46), (47), (48), (50), (51), (52), (53), 
	(54), (55), (49), (56), (57), (59), (61), (62), (63), (64)

insert into sep1_insect values(13), (27), (58), (60), (1), (2), (3), (4), (5), (6), (7), 
	(8), (9), (10), (11), (14), (15), (16), (17), (20), (22), (23), (26), (28), (29),
	(30), (31), (32), (33), (35), (36), (39), (49), (56), (57), (59), (61), (62), (64)

insert into sep2_insect values (13), (27), (58), (60), (1), (2), (3), (4), (5), (6), (7), 
	(8), (9), (10), (11), (14), (15), (16), (17), (20), (22), (23), (26), (28), (29),
	(30), (31), (32), (33), (35), (36), (39), (49), (56), (57), (59), (61), (62), (64)

insert into oct_insect values (13), (27), (58), (60), (5), (14), (15), (16), (17), (23), 
	(26), (31), (32), (36), (37), (38), (39), (57), (61), (62)

insert into nov_insect values (13), (27), (58), (60), (5), (14), (15), (16), (17), 
	(31), (34), (36), (37), (39), (57), (61)

insert into dec_insect values (13), (27), (58), (60), (34), (37), (41), (61)


