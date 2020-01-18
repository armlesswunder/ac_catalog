--select * from fish

--select fish with index included in jan_fish table of indecis
--select * from fish where "Index" in (select * from jan_fish)

drop table jan_fish
drop table feb_fish
drop table mar_fish 
drop table apr_fish 
drop table may_fish 
drop table jun_fish 
drop table jul_fish 
drop table aug1_fish
drop table aug2_fish
drop table sep1_fish
drop table sep2_fish
drop table oct_fish 
drop table nov_fish 
drop table dec_fish

--these tables hold the idecis of all fish available in a particular month.
--see the above select statement to see how these elements are useful
create table jan_fish (id int primary key)
create table feb_fish (id int primary key)
create table mar_fish (id int primary key)
create table apr_fish (id int primary key)
create table may_fish (id int primary key)
create table jun_fish (id int primary key)
create table jul_fish (id int primary key)
create table aug1_fish (id int primary key)
create table aug2_fish (id int primary key)
create table sep1_fish (id int primary key)
create table sep2_fish (id int primary key)
create table oct_fish (id int primary key)
create table nov_fish (id int primary key)
create table dec_fish (id int primary key)

--insert index of each fish which appears in a given month (or possibly half-month)
insert into jan_fish values (1), (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (19), (20), (22), (27), (38), (47), (49), (50), (51), (52), (53), (54), 
	(55), (57), (58), (64)

insert into feb_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (1), (19), (22), (27), 
	(38), (51), (53), (55), (57), (58)

insert into mar_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (14), (19), (24), (25), 
	(26), (48), (51), (53), (54), (57), (58)

insert into apr_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (10), (11), (14), (24), 
	(25), (26), (30), (32), (40), (41), (42), (43), (45), (48), (51), (53), 
	(54)

insert into may_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (10), (11), (12), (14), 
	(15), (24), (25), (26), (30), (31), (32), (40), (41), (42), (43), (45), 
	(48), (53), (54)

insert into jun_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (10), (11), (12), (15), 
	(16), (17), (24), (25), (26), (30), (31), (32), (33), (34), (35), (36), 
	(40), (41), (42), (43), (45), (48), (53), (54), (61), (62), (63)

insert into jul_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (10), (11), (12), (15), 
	(16), (17), (23), (30), (31), (32), (33), (34), (35), (36), (37), (40), 
	(41), (42), (43), (44), (45), (46), (48), (53), (54), (59), (61), (62), 
	(63)


insert into aug1_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (10), (11), (12), (15), (16), 
	(17), (23), (30), (31), (32), (33), (34), (35), (36), (37), (40), (41), 
	(42), (43), (44), (45), (46), (48), (53), (56), (59), (60), (61), (62), 
	(63)

insert into aug2_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (10), (11), (12), (15), (16), 
	(17), (23), (30), (31), (32), (33), (34), (35), (36), (37), (40), (41), 
	(42), (43), (44), (45), (46), (48), (56), (59), (60), (61), (62), (63), 
	(39)

insert into sep1_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (11), (15), (16), (21), (23), 
	(26), (24), (28), (29), (30), (31), (32), (33), (34), (35), (36), (37), 
	(40), (41), (42), (43), (45), (46), (48), (56), (59), (60), (61), (62), (63)

insert into sep2_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (15), (21), (26), (24), (28), 
	(29), (30), (31), (32), (35), (36), (37), 
	(40), (41), (42), (43), (45), (46), (48), (54), (56), (59), (60), (61), (62), (63)

insert into oct_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (15), (19), (21), (24), (26), 
	(30), (31), (32), (40), (45), (51), (48), (54), (56), (60)

insert into nov_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (1), (19), (21), (24), (26), (30), 
	(32), (40), (45), (51), (48), (54), (55), (57), (58), (60)

insert into dec_fish values (2), (3), (4), (5), (6), (7), (8), (9), (13), 
	(18), (20), (47), (49), (50), (52), (64), (1), (19), (21), (22), (24), (26), (27), 
	(38), (51), (53), (54), (55), (57), (58)