CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        title VARCHAR(200) NOT NULL,
        instructions VARCHAR(5000) NOT NULL,
        img VARCHAR(1200) NOT NULL,
        category VARCHAR(100) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id)
    ) default charset utf8;

INSERT INTO
    recipes (
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        "Testing Burger",
        "Don't eat this",
        "https://images.unsplash.com/photo-1625813506062-0aeb1d7a094b?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YnVyZ2VyfGVufDB8fDB8fHww",
        "Burger",
        "652eeb40fd4290362d526d82"
    );

SELECT * FROM recipes;