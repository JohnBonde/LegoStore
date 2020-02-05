USE bondelego;
-- CREATE TABLE bricks (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
--   );

-- CREATE TABLE sets (
-- id int NOT NULL AUTO_INCREMENT,
-- name VARCHAR(255) NOT NULL,
-- PRIMARY KEY (id)
-- );

-- CREATE TABLE bricksets (
-- id int NOT NULL AUTO_INCREMENT,
-- brickId int NOT NULL,
-- setId int NOT NULL,
-- PRIMARY KEY (id),

-- FOREIGN KEY (brickId)
-- REFERENCES bricks(id)
-- ON DELETE CASCADE,
    
-- FOREIGN KEY (setId)
-- REFERENCES sets(id)
-- ON DELETE CASCADE
-- );

-- INSERT INTO bricks (name) VALUES ("4x4");
-- INSERT INTO bricks (name) VALUES ("2x2");
-- INSERT INTO bricks (name) VALUES ("1x2");

-- INSERT INTO sets (name) VALUES ("block");
-- INSERT INTO sets (name) VALUES ("tower");
-- INSERT INTO sets (name) VALUES ("foot trap");

-- INSERT INTO bricksets (brickId, setId) VALUES (1, 2);
-- INSERT INTO bricksets (brickId, setId) VALUES (1, 3);
-- INSERT INTO bricksets (brickId, setId) VALUES (2, 3);