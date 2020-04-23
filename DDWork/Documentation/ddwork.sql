/*
 Navicat Premium Data Transfer

 Source Server         : root
 Source Server Type    : MySQL
 Source Server Version : 80019
 Source Host           : localhost:3306
 Source Schema         : ddwork

 Target Server Type    : MySQL
 Target Server Version : 80019
 File Encoding         : 65001

 Date: 23/04/2020 12:08:50
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(95) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20200419135929_init', '3.1.3');
INSERT INTO `__efmigrationshistory` VALUES ('20200419151826_init2', '3.1.3');
INSERT INTO `__efmigrationshistory` VALUES ('20200419171939_init3', '3.1.3');
INSERT INTO `__efmigrationshistory` VALUES ('20200419172856_init4', '3.1.3');
INSERT INTO `__efmigrationshistory` VALUES ('20200423013801_init5', '3.1.3');
INSERT INTO `__efmigrationshistory` VALUES ('20200423015903_init6', '3.1.3');
INSERT INTO `__efmigrationshistory` VALUES ('20200423031028_init7', '3.1.3');
INSERT INTO `__efmigrationshistory` VALUES ('20200423040427_init8', '3.1.3');

-- ----------------------------
-- Table structure for car
-- ----------------------------
DROP TABLE IF EXISTS `car`;
CREATE TABLE `car`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `car_no` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `car_load` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `bank_no` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `bank_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of car
-- ----------------------------
INSERT INTO `car` VALUES (3, '司机A', 'A000000', '30', '123456789', 'A银行', '2020.04.20 01:07:00', '15100000000');
INSERT INTO `car` VALUES (4, '司机B', 'B000000', '35', '123456798', 'B银行', '2020.04.20 01:07:10', '1510000000');

-- ----------------------------
-- Table structure for contract
-- ----------------------------
DROP TABLE IF EXISTS `contract`;
CREATE TABLE `contract`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `weight` double NOT NULL,
  `contract_price` double NOT NULL,
  `delivery_date` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `customerid` int(0) NULL DEFAULT NULL,
  `materialid` int(0) NULL DEFAULT NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `fine` double NOT NULL DEFAULT 0,
  `print_price` double NOT NULL DEFAULT 0,
  `print_weight` double NOT NULL DEFAULT 0,
  `debt_price` double NOT NULL DEFAULT 0,
  `real_receive_price` double NOT NULL DEFAULT 0,
  `should_receive_price` double NOT NULL DEFAULT 0,
  `unit_price` double NOT NULL DEFAULT 0,
  `unprint_price` double NOT NULL DEFAULT 0,
  `unprint_weight` double NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `IX_contract_customerid`(`customerid`) USING BTREE,
  INDEX `IX_contract_materialid`(`materialid`) USING BTREE,
  CONSTRAINT `FK_contract_customer_customerid` FOREIGN KEY (`customerid`) REFERENCES `customer` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contract_material_materialid` FOREIGN KEY (`materialid`) REFERENCES `material` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of contract
-- ----------------------------
INSERT INTO `contract` VALUES (1, 35, 35000, '2019-10-31', 2, 2, '2020.04.20 02:09:59', 100, 35000, 35, 0, 0, 0, 0, 0, 0);

-- ----------------------------
-- Table structure for customer
-- ----------------------------
DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `contact` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of customer
-- ----------------------------
INSERT INTO `customer` VALUES (1, '内蒙古力善商贸有限公司', '内蒙古乌斯太晨宏力', '联系人A', '1510000000', '2020.04.20 01:09:44');
INSERT INTO `customer` VALUES (2, '顾客B', '地址B', '联系人B', '1500000000', '2020.04.20 01:09:44');

-- ----------------------------
-- Table structure for expenditrueviewmodel
-- ----------------------------
DROP TABLE IF EXISTS `expenditrueviewmodel`;
CREATE TABLE `expenditrueviewmodel`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `sharehloder_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `material_count_price` double NOT NULL,
  `carriage_count_price` double NOT NULL,
  `car_no` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `date` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for expenditure
-- ----------------------------
DROP TABLE IF EXISTS `expenditure`;
CREATE TABLE `expenditure`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `material_count_price` double NOT NULL,
  `carriage_count_price` double NOT NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `shareholderid` int(0) NULL DEFAULT NULL,
  `transportationid` int(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `IX_expenditure_shareholderid`(`shareholderid`) USING BTREE,
  INDEX `IX_expenditure_transportationid`(`transportationid`) USING BTREE,
  CONSTRAINT `FK_expenditure_shareholder_shareholderid` FOREIGN KEY (`shareholderid`) REFERENCES `shareholder` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_expenditure_transportation_transportationid` FOREIGN KEY (`transportationid`) REFERENCES `transportation` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for gainlossviewmodel
-- ----------------------------
DROP TABLE IF EXISTS `gainlossviewmodel`;
CREATE TABLE `gainlossviewmodel`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `gain_or_loss` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `item` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `price` double NOT NULL,
  `date` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for income
-- ----------------------------
DROP TABLE IF EXISTS `income`;
CREATE TABLE `income`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `count_price` double NOT NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `customerid` int(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `IX_income_customerid`(`customerid`) USING BTREE,
  CONSTRAINT `FK_income_customer_customerid` FOREIGN KEY (`customerid`) REFERENCES `customer` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of income
-- ----------------------------
INSERT INTO `income` VALUES (2, 350000, '2020.04.20 02:09:52', 1);

-- ----------------------------
-- Table structure for material
-- ----------------------------
DROP TABLE IF EXISTS `material`;
CREATE TABLE `material`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `unit` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of material
-- ----------------------------
INSERT INTO `material` VALUES (1, '原料A', '吨', '2020.04.20 01:10:17');
INSERT INTO `material` VALUES (2, '原料B', '吨', '2020.04.20 01:10:24');

-- ----------------------------
-- Table structure for material_unit_price
-- ----------------------------
DROP TABLE IF EXISTS `material_unit_price`;
CREATE TABLE `material_unit_price`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `price` double NOT NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `materialid` int(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `IX_material_unit_price_materialid`(`materialid`) USING BTREE,
  CONSTRAINT `FK_material_unit_price_material_materialid` FOREIGN KEY (`materialid`) REFERENCES `material` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of material_unit_price
-- ----------------------------
INSERT INTO `material_unit_price` VALUES (1, 350, '2020.04.20 02:15:00', 2);
INSERT INTO `material_unit_price` VALUES (2, 500, '2020.04.20 02:15:23', 1);

-- ----------------------------
-- Table structure for shareholder
-- ----------------------------
DROP TABLE IF EXISTS `shareholder`;
CREATE TABLE `shareholder`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of shareholder
-- ----------------------------
INSERT INTO `shareholder` VALUES (1, '合伙人A', '1500000000', '2020.04.20 01:10:48');
INSERT INTO `shareholder` VALUES (2, '合伙人B', '1500000000', '2020.04.20 01:10:54');

-- ----------------------------
-- Table structure for shareholderviewmodel
-- ----------------------------
DROP TABLE IF EXISTS `shareholderviewmodel`;
CREATE TABLE `shareholderviewmodel`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `shareholder_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `out_count_price` double NOT NULL,
  `average_count_price` double NOT NULL,
  `difference_count_price` double NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for supply
-- ----------------------------
DROP TABLE IF EXISTS `supply`;
CREATE TABLE `supply`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `contact` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of supply
-- ----------------------------
INSERT INTO `supply` VALUES (1, '供应商A', '地址A', '联系人A', '1500000000', '2020.04.20 01:26:04');
INSERT INTO `supply` VALUES (2, '供应商B', '地址B', '联系人B', '1500000000', '2020.04.20 01:26:23');

-- ----------------------------
-- Table structure for transportation
-- ----------------------------
DROP TABLE IF EXISTS `transportation`;
CREATE TABLE `transportation`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `material_weight` double NOT NULL,
  `carriage_weight` double NOT NULL,
  `material_unit_price` double NOT NULL,
  `carriage_unit_price` double NOT NULL,
  `material_count_price` double NOT NULL,
  `carriage_count_price` double NOT NULL,
  `start_date` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `end_date` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `customerid` int(0) NULL DEFAULT NULL,
  `shareholderid` int(0) NULL DEFAULT NULL,
  `carid` int(0) NULL DEFAULT NULL,
  `supplyid` int(0) NULL DEFAULT NULL,
  `materialid` int(0) NULL DEFAULT NULL,
  `carriage_should_count_price` double NOT NULL DEFAULT 0,
  `service_charge` double NOT NULL DEFAULT 0,
  `pay_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `IX_transportation_carid`(`carid`) USING BTREE,
  INDEX `IX_transportation_customerid`(`customerid`) USING BTREE,
  INDEX `IX_transportation_materialid`(`materialid`) USING BTREE,
  INDEX `IX_transportation_shareholderid`(`shareholderid`) USING BTREE,
  INDEX `IX_transportation_supplyid`(`supplyid`) USING BTREE,
  CONSTRAINT `FK_transportation_car_carid` FOREIGN KEY (`carid`) REFERENCES `car` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_transportation_customer_customerid` FOREIGN KEY (`customerid`) REFERENCES `customer` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_transportation_material_materialid` FOREIGN KEY (`materialid`) REFERENCES `material` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_transportation_shareholder_shareholderid` FOREIGN KEY (`shareholderid`) REFERENCES `shareholder` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_transportation_supply_supplyid` FOREIGN KEY (`supplyid`) REFERENCES `supply` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of transportation
-- ----------------------------
INSERT INTO `transportation` VALUES (3, 10, 9, 0, 1, 0, 7, '2020.04.23', '2020.05.02', '2020.04.23 10:44:02', 1, 2, 3, 1, 1, 9, 2, '2020.04.25');

-- ----------------------------
-- Table structure for transportationviewmodel
-- ----------------------------
DROP TABLE IF EXISTS `transportationviewmodel`;
CREATE TABLE `transportationviewmodel`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `material_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `supply_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `car_no` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `start_date` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `end_date` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `customer_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `material_weight` double NOT NULL,
  `carriage_weight` double NOT NULL,
  `material_unit_price` double NOT NULL,
  `carriage_unit_price` double NOT NULL,
  `material_count_price` double NOT NULL,
  `carriage_count_price` double NOT NULL,
  `shareholder_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `car_name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `car_phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `carriage_should_count_price` double NOT NULL DEFAULT 0,
  `pay_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `service_charge` double NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` int(0) NOT NULL AUTO_INCREMENT,
  `name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `privileges` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `create_time` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ding_id` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, '用户A', '发货员', '2020.04.20 05:20:00', NULL);
INSERT INTO `user` VALUES (2, '用户B', '管理员', '2020.04.20 05:20:04', NULL);

SET FOREIGN_KEY_CHECKS = 1;
