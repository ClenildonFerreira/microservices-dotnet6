CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `product` (
    `id` bigint NOT NULL AUTO_INCREMENT,
    `name` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `description` varchar(500) CHARACTER SET utf8mb4 NULL,
    `price` decimal(65,30) NOT NULL,
    `category_name` varchar(50) CHARACTER SET utf8mb4 NULL,
    `image_url` varchar(255) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_product` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230413183648_CreateProductDataTableOnDB', '7.0.5');

COMMIT;

