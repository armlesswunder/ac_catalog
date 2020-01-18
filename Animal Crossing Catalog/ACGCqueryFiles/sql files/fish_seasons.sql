select * from acgc_fish

--select fish with index included in jan_fish table of indecis
--select * from fish where "Index" in (select * from jan_fish)

drop table acgc_jan_fish
drop table acgc_feb_fish
drop table acgc_mar_fish 
drop table acgc_apr_fish 
drop table acgc_may_fish 
drop table acgc_jun_fish 
drop table acgc_jul_fish 
drop table acgc_aug1_fish
drop table acgc_aug2_fish
drop table acgc_sep1_fish
drop table acgc_sep2_fish
drop table acgc_oct_fish 
drop table acgc_nov_fish 
drop table acgc_dec_fish

--these tables hold the idecis of all fish available in a particular month.
--see the above select statement to see how these elements are useful
create table acgc_jan_fish (id int primary key)
create table acgc_feb_fish (id int primary key)
create table acgc_mar_fish (id int primary key)
create table acgc_apr_fish (id int primary key)
create table acgc_may_fish (id int primary key)
create table acgc_jun_fish (id int primary key)
create table acgc_jul_fish (id int primary key)
create table acgc_aug1_fish (id int primary key)
create table acgc_aug2_fish (id int primary key)
create table acgc_sep1_fish (id int primary key)
create table acgc_sep2_fish (id int primary key)
create table acgc_oct_fish (id int primary key)
create table acgc_nov_fish (id int primary key)
create table acgc_dec_fish (id int primary key)

--insert index of each fish which appears in a given month (or possibly half-month)
insert into acgc_jan_fish values(1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (9), (18), (23),
(36)

insert into acgc_feb_fish values(1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (9), (18), (23),
(36)

insert into acgc_mar_fish values(1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (10), (20), (21),
(22), (36), (38)

insert into acgc_apr_fish values(1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (10), (20), (21),
(22), (27), (32), (34), (36), (38)

insert into acgc_may_fish values(1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6), (10), (20),
(21), (22), (27), (28), (32), (33), (34), (36), (38)

insert into acgc_jun_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6), (7), (15),
(16), (20), (21), (22), (27), (28), (29), (30), (32), (33), (34), (36), (38)

insert into acgc_jul_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6), (7), (15),
(16), (19), (27), (28), (29), (30), (32), (33), (34), (36), (38), (39)

insert into acgc_aug1_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6), (7), (15),
(16), (19), (27), (28), (29), (30), (32), (33), (34), (36), (38), (39)

insert into acgc_aug2_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6), (7), (15),
(16), (19), (27), (28), (29), (30), (32), (33), (34), (35), (38), (39)

insert into acgc_sep1_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6),
(16), (19), (24), (27), (28), (29), (30), (32), (38), (39)

insert into acgc_sep2_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6), (27), (28),
(36), (38), (39)

insert into acgc_oct_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (6), (27), (28),
(36), (38)

insert into acgc_nov_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), (27), (36), (38)

insert into acgc_dec_fish values (1), (2), (3), (4), (5), (8), (11), (12), (13), (14), (17), (25), (26), (31), (37), 
(9), (18), (23), (36)

--my idecis were wrong because I missused the fish catalog provided to me
update acgc_jan_fish set id += 1 where id > 1
update acgc_feb_fish set id += 1 where id > 1
update acgc_mar_fish set id += 1 where id > 1
update acgc_apr_fish set id += 1 where id > 1
update acgc_may_fish set id += 1 where id > 1
update acgc_jun_fish set id += 1 where id > 1
update acgc_jul_fish set id += 1 where id > 1
update acgc_aug1_fish set id += 1 where id > 1
update acgc_aug2_fish set id += 1 where id > 1
update acgc_sep1_fish set id += 1 where id > 1
update acgc_sep2_fish set id += 1 where id > 1
update acgc_oct_fish set id += 1 where id > 1
update acgc_nov_fish set id += 1 where id > 1
update acgc_dec_fish set id += 1 where id > 1

--insert brook trout index into each table
insert into acgc_jan_fish values(2)
insert into acgc_feb_fish values(2)
insert into acgc_mar_fish values(2)
insert into acgc_apr_fish values(2)
insert into acgc_may_fish values(2)
insert into acgc_jun_fish values (2)
insert into acgc_jul_fish values (2)
insert into acgc_aug1_fish values (2)
insert into acgc_aug2_fish values (2)
insert into acgc_sep1_fish values (2)
insert into acgc_sep2_fish values (2)
insert into acgc_oct_fish values (2)
insert into acgc_nov_fish values(2)
insert into acgc_dec_fish values (2)
