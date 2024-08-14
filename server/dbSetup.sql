CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE houses(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  bedrooms TINYINT UNSIGNED NOT NULL,
  bathrooms TINYINT UNSIGNED NOT NULL,
  levels TINYINT UNSIGNED NOT NULL,
  imgUrl TEXT NOT NULL,
  year SMALLINT UNSIGNED NOT NULL,
  price INT UNSIGNED NOT NULL,
  description TEXT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

INSERT INTO 
houses (bedrooms, bathrooms, levels, imgUrl, year, price, description, creatorId)
VALUES
(1, 1, 1, "https://images.unsplash.com/photo-1502592238809-4cba3c1b80bc?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 1855, 1400000, "A reasonably priced house", "66abb758200ee1bc80c6579e")
