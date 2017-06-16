/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50515
Source Host           : localhost:3306
Source Database       : mvc

Target Server Type    : MYSQL
Target Server Version : 50515
File Encoding         : 65001

Date: 2017-06-16 07:49:50
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for sys_action
-- ----------------------------
DROP TABLE IF EXISTS `sys_action`;
CREATE TABLE `sys_action` (
  `ACTION_ID` varchar(20) NOT NULL,
  `MENU_ID` varchar(20) DEFAULT NULL,
  `ACTION_NAME` varchar(50) DEFAULT NULL,
  `ACTION_URL` varchar(200) DEFAULT NULL,
  `ACTION_ICONCLASS` varchar(50) DEFAULT NULL,
  `ACTION_ICONURL` varchar(150) DEFAULT NULL,
  `ACTION_BID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ACTION_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_action
-- ----------------------------
INSERT INTO `sys_action` VALUES ('12', 'M001001', '测试1', 'api/test1', 'iconCls', null, null);
INSERT INTO `sys_action` VALUES ('13', 'M001001', '测试2', 'api/test2', 'iconCls', null, null);
INSERT INTO `sys_action` VALUES ('14', 'M001001', '测试2', 'api/test2', 'iconCls', null, null);
INSERT INTO `sys_action` VALUES ('B001', 'M001002', '测试1', '12', 'iconCls', null, null);

-- ----------------------------
-- Table structure for sys_department
-- ----------------------------
DROP TABLE IF EXISTS `sys_department`;
CREATE TABLE `sys_department` (
  `DEPARTMENT_ID` varchar(50) NOT NULL,
  `DEPARTMENT_NAME` varchar(50) DEFAULT NULL,
  `DEPARTMENT_PID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`DEPARTMENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_department
-- ----------------------------
INSERT INTO `sys_department` VALUES ('JT', '中南海', '0');
INSERT INTO `sys_department` VALUES ('JT01', '中国电力公司', 'JT');
INSERT INTO `sys_department` VALUES ('JT0101', '南方电网', 'JT01');
INSERT INTO `sys_department` VALUES ('JT0102', '北京电网', 'JT01');
INSERT INTO `sys_department` VALUES ('JT02', '中国北方公司', 'JT');
INSERT INTO `sys_department` VALUES ('JT03', '中国石化', 'JT');

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu` (
  `MENU_ID` varchar(50) NOT NULL,
  `MENU_PID` varchar(50) DEFAULT NULL,
  `MENU_URL` varchar(50) DEFAULT NULL,
  `MENU_NAME` varchar(50) DEFAULT NULL,
  `MENU_ICONURL` varchar(150) DEFAULT NULL,
  `MENU_ICONCLASS` varchar(50) DEFAULT NULL,
  `MENU_SEQ` decimal(11,0) NOT NULL,
  `IS_ENABLE` decimal(4,0) DEFAULT NULL,
  `DATE_CREATE` datetime DEFAULT NULL,
  PRIMARY KEY (`MENU_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES ('M001', '0', null, '系统管理', null, 'icon-computer', '0', '0', '2017-03-11 00:00:00');
INSERT INTO `sys_menu` VALUES ('M001001', 'M001', '/Sys/SysUser/Index', '用户管理', '/Content/Images/icons/user.png', 'icon-user', '1', '0', '2017-03-11 12:00:00');
INSERT INTO `sys_menu` VALUES ('M001002', 'M001', '/Sys/SysMenu/Index', '菜单管理', '/Content/Images/icons/application_view_columns.png', 'icon-application_view_columns', '2', '0', '2017-03-11 12:00:00');
INSERT INTO `sys_menu` VALUES ('M002', 'M001', '/Sys/SysLog/Index', '系统日志', '/Content/Images/icons/page_white_text.png', 'icon-page_white_text', '5', '1', '2017-03-12 12:02:52');
INSERT INTO `sys_menu` VALUES ('M003', 'M001', '/Sys/SysRole/Index', '角色管理', '/Content/Images/icons/user_key.png', 'icon-user_key', '3', '0', '2017-03-12 07:26:45');
INSERT INTO `sys_menu` VALUES ('M004', 'M001', '/Sys/SysDepartment/Index', '部门管理', null, 'icon-application_osx_home', '4', '0', '2017-05-20 23:49:02');

-- ----------------------------
-- Table structure for sys_paramconfig
-- ----------------------------
DROP TABLE IF EXISTS `sys_paramconfig`;
CREATE TABLE `sys_paramconfig` (
  `ID` decimal(11,0) NOT NULL,
  `SPNAME` varchar(50) DEFAULT NULL,
  `ARGNAME` varchar(50) DEFAULT NULL,
  `DATATYPE` varchar(50) DEFAULT NULL,
  `DIRECTION` varchar(50) DEFAULT NULL,
  `SEQ` decimal(11,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_paramconfig
-- ----------------------------
INSERT INTO `sys_paramconfig` VALUES ('1', 'sp_sysUser_query', '@userId', 'string', 'in', '1');

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role` (
  `ROLE_ID` varchar(20) NOT NULL,
  `ROLE_NAME` varchar(50) DEFAULT NULL,
  `ROLE_DESC` varchar(200) DEFAULT NULL,
  `CREATOR` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES ('0', '超级管理员', '超级管理员', null);
INSERT INTO `sys_role` VALUES ('121212', '测试', '测试2111', null);
INSERT INTO `sys_role` VALUES ('R001', '测试角色', '测试角色11', null);
INSERT INTO `sys_role` VALUES ('R002', '一炼钢操作员', '测试角色11', null);
INSERT INTO `sys_role` VALUES ('R003', '管理员1', '管理员1', null);
INSERT INTO `sys_role` VALUES ('R005', 'R005', 'R005', null);
INSERT INTO `sys_role` VALUES ('R006', 'R006', 'R006', null);
INSERT INTO `sys_role` VALUES ('R007', 'R007', 'R007', null);

-- ----------------------------
-- Table structure for sys_role_action
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_action`;
CREATE TABLE `sys_role_action` (
  `ROLE_ID` varchar(20) NOT NULL,
  `ACTION_ID` varchar(20) NOT NULL,
  PRIMARY KEY (`ROLE_ID`,`ACTION_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role_action
-- ----------------------------
INSERT INTO `sys_role_action` VALUES ('R001', '12');
INSERT INTO `sys_role_action` VALUES ('R001', '13');
INSERT INTO `sys_role_action` VALUES ('R001', '14');
INSERT INTO `sys_role_action` VALUES ('R003', '12');
INSERT INTO `sys_role_action` VALUES ('R003', '13');
INSERT INTO `sys_role_action` VALUES ('R003', '14');
INSERT INTO `sys_role_action` VALUES ('R003', 'B001');

-- ----------------------------
-- Table structure for sys_role_member
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_member`;
CREATE TABLE `sys_role_member` (
  `ROLE_ID` varchar(50) NOT NULL,
  `ROLE_PID` varchar(50) NOT NULL,
  `CREATOR` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role_member
-- ----------------------------
INSERT INTO `sys_role_member` VALUES ('R001', '0', 'admin1');
INSERT INTO `sys_role_member` VALUES ('R002', 'R001', null);
INSERT INTO `sys_role_member` VALUES ('R003', 'R001', null);
INSERT INTO `sys_role_member` VALUES ('R004', 'R002', null);
INSERT INTO `sys_role_member` VALUES ('R005', 'R003', null);
INSERT INTO `sys_role_member` VALUES ('R006', 'R003', null);
INSERT INTO `sys_role_member` VALUES ('R007', '121212', 'admin');

-- ----------------------------
-- Table structure for sys_role_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_menu`;
CREATE TABLE `sys_role_menu` (
  `MENU_ID` varchar(20) NOT NULL,
  `ROLE_ID` varchar(50) NOT NULL,
  PRIMARY KEY (`MENU_ID`,`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role_menu
-- ----------------------------
INSERT INTO `sys_role_menu` VALUES ('M001', 'R001');
INSERT INTO `sys_role_menu` VALUES ('M001', 'R002');
INSERT INTO `sys_role_menu` VALUES ('M001', 'R003');
INSERT INTO `sys_role_menu` VALUES ('M001', 'R005');
INSERT INTO `sys_role_menu` VALUES ('M001', 'undefined');
INSERT INTO `sys_role_menu` VALUES ('M001001', 'R001');
INSERT INTO `sys_role_menu` VALUES ('M001001', 'R002');
INSERT INTO `sys_role_menu` VALUES ('M001001', 'R003');
INSERT INTO `sys_role_menu` VALUES ('M001001', 'R005');
INSERT INTO `sys_role_menu` VALUES ('M001001', 'undefined');
INSERT INTO `sys_role_menu` VALUES ('M001002', 'R001');
INSERT INTO `sys_role_menu` VALUES ('M001002', 'R002');
INSERT INTO `sys_role_menu` VALUES ('M001002', 'R003');
INSERT INTO `sys_role_menu` VALUES ('M001002', 'undefined');
INSERT INTO `sys_role_menu` VALUES ('M002', 'R003');
INSERT INTO `sys_role_menu` VALUES ('M003', 'R001');
INSERT INTO `sys_role_menu` VALUES ('M003', 'R003');
INSERT INTO `sys_role_menu` VALUES ('M003', 'undefined');
INSERT INTO `sys_role_menu` VALUES ('M004', 'R003');
INSERT INTO `sys_role_menu` VALUES ('R001', 'M001');
INSERT INTO `sys_role_menu` VALUES ('R001', 'M001001');
INSERT INTO `sys_role_menu` VALUES ('R001', 'M001002');

-- ----------------------------
-- Table structure for sys_sequence
-- ----------------------------
DROP TABLE IF EXISTS `sys_sequence`;
CREATE TABLE `sys_sequence` (
  `SEQ_ID` varchar(20) NOT NULL,
  `SEQ_NAME` varchar(50) DEFAULT NULL,
  `C_FORMAT` varchar(20) DEFAULT NULL,
  `C_CURDATE` varchar(255) DEFAULT NULL,
  `N_STEP` int(11) DEFAULT NULL,
  `C_CURVAL` varchar(20) DEFAULT NULL,
  `C_VAL` varchar(50) DEFAULT NULL,
  `C_PADCHAR` varchar(10) DEFAULT NULL,
  `C_PADLEN` int(10) DEFAULT NULL,
  `C_FORMAT_TYPE` varchar(10) DEFAULT NULL,
  `C_PRECHAR` varchar(10) DEFAULT NULL,
  `C_VERSION` decimal(10,0) DEFAULT '0',
  PRIMARY KEY (`SEQ_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_sequence
-- ----------------------------
INSERT INTO `sys_sequence` VALUES ('SYS_ROLE.ROLE_ID', null, 'yyMMdd', '170614', '1', '7644', 'ZG17061407644', '0', '5', '0', 'ZG', null);

-- ----------------------------
-- Table structure for sys_setting
-- ----------------------------
DROP TABLE IF EXISTS `sys_setting`;
CREATE TABLE `sys_setting` (
  `ID` decimal(11,0) NOT NULL,
  `CODE` varchar(50) DEFAULT NULL,
  `VALUE` varchar(120) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_setting
-- ----------------------------
INSERT INTO `sys_setting` VALUES ('1', 'SYS_NAME', '测试系统');
INSERT INTO `sys_setting` VALUES ('2', 'SYS_EMAIL', 'chenl_11@163.com');
INSERT INTO `sys_setting` VALUES ('3', 'SYS_EMAIL_USER', 'chenl_11');
INSERT INTO `sys_setting` VALUES ('4', 'SYS_EMAIL_PWD', 'bbls63152');
INSERT INTO `sys_setting` VALUES ('5', 'SYS_EMAIL_POT', 'MM.163.COM');

-- ----------------------------
-- Table structure for sys_sigin_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_sigin_log`;
CREATE TABLE `sys_sigin_log` (
  `LINE_ID` decimal(11,0) NOT NULL,
  `LOCAL_IP` varchar(50) DEFAULT NULL,
  `NET_IP` varchar(50) DEFAULT NULL,
  `USER_ID` varchar(50) DEFAULT NULL,
  `USER_NAME` varchar(50) DEFAULT NULL,
  `LOGIN_ADDRESS` varchar(200) DEFAULT NULL,
  `LOGIN_DATE` datetime DEFAULT NULL,
  PRIMARY KEY (`LINE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_sigin_log
-- ----------------------------
INSERT INTO `sys_sigin_log` VALUES ('13', '192.168.1.107', '112.20.190.11', 'admin4', '测试账号4', '江苏省淮安市', '2017-04-21 22:59:05');
INSERT INTO `sys_sigin_log` VALUES ('14', '127.0.0.1', '36.149.227.203', 'admin4', '测试账号4', '江苏省淮安市', '2017-04-21 23:00:19');
INSERT INTO `sys_sigin_log` VALUES ('15', '192.168.1.107', '36.149.227.203', 'admin', '系统管理员', '江苏省淮安市', '2017-04-21 23:02:24');
INSERT INTO `sys_sigin_log` VALUES ('16', '192.168.1.102', '36.149.227.203', 'admin4', '测试账号4', '江苏省淮安市', '2017-04-21 23:03:55');
INSERT INTO `sys_sigin_log` VALUES ('17', '192.168.11.144', '122.195.215.20', 'admin7', '测试账号7', '江苏省淮安市', '2017-04-24 09:44:23');
INSERT INTO `sys_sigin_log` VALUES ('18', '192.168.11.144', '122.195.215.20', 'admin', '系统管理员', '江苏省淮安市', '2017-04-24 14:28:54');
INSERT INTO `sys_sigin_log` VALUES ('19', '127.0.0.1', null, 'admin', '系统管理员', null, '2017-05-02 12:42:10');
INSERT INTO `sys_sigin_log` VALUES ('20', '127.0.0.1', null, 'admin', '系统管理员', null, '2017-05-02 12:45:31');
INSERT INTO `sys_sigin_log` VALUES ('21', '127.0.0.1', null, 'admin', '系统管理员', null, '2017-05-03 08:09:16');
INSERT INTO `sys_sigin_log` VALUES ('22', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-18 10:04:18');
INSERT INTO `sys_sigin_log` VALUES ('23', '192.168.69.6', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-18 14:01:14');
INSERT INTO `sys_sigin_log` VALUES ('24', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 20:47:00');
INSERT INTO `sys_sigin_log` VALUES ('25', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 21:13:55');
INSERT INTO `sys_sigin_log` VALUES ('26', '::1', '36.149.139.72', 'admin1', '测试账号1', '江苏省常州市', '2017-05-18 21:14:55');
INSERT INTO `sys_sigin_log` VALUES ('27', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 21:17:33');
INSERT INTO `sys_sigin_log` VALUES ('28', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 21:18:03');
INSERT INTO `sys_sigin_log` VALUES ('29', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 21:18:33');
INSERT INTO `sys_sigin_log` VALUES ('30', '::1', '36.149.139.72', 'admin1', '测试账号1', '江苏省常州市', '2017-05-18 21:22:00');
INSERT INTO `sys_sigin_log` VALUES ('31', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 21:24:27');
INSERT INTO `sys_sigin_log` VALUES ('32', '::1', '36.149.139.72', 'admin2', '测试账号2', '江苏省常州市', '2017-05-18 21:25:04');
INSERT INTO `sys_sigin_log` VALUES ('33', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 21:28:39');
INSERT INTO `sys_sigin_log` VALUES ('34', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-18 21:51:55');
INSERT INTO `sys_sigin_log` VALUES ('35', '::1', '36.149.139.72', 'admin3', '测试账号3', '江苏省常州市', '2017-05-18 22:22:24');
INSERT INTO `sys_sigin_log` VALUES ('36', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-19 08:13:10');
INSERT INTO `sys_sigin_log` VALUES ('37', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-19 14:28:15');
INSERT INTO `sys_sigin_log` VALUES ('38', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-19 15:50:29');
INSERT INTO `sys_sigin_log` VALUES ('39', '::1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-19 21:48:27');
INSERT INTO `sys_sigin_log` VALUES ('40', '127.0.0.1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-19 21:58:47');
INSERT INTO `sys_sigin_log` VALUES ('41', '127.0.0.1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-20 09:50:00');
INSERT INTO `sys_sigin_log` VALUES ('42', '192.168.232.104', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-20 09:59:03');
INSERT INTO `sys_sigin_log` VALUES ('43', '127.0.0.1', '36.149.139.72', 'admin', '系统管理员', '江苏省常州市', '2017-05-20 11:49:08');
INSERT INTO `sys_sigin_log` VALUES ('44', '127.0.0.1', '36.149.200.168', 'admin', '系统管理员', '江苏省常州市', '2017-05-20 22:49:44');
INSERT INTO `sys_sigin_log` VALUES ('45', '192.168.232.176', '36.149.200.168', 'admin', '系统管理员', '江苏省常州市', '2017-05-21 00:54:00');
INSERT INTO `sys_sigin_log` VALUES ('46', '127.0.0.1', '36.149.200.168', 'admin', '系统管理员', '江苏省常州市', '2017-05-21 21:35:26');
INSERT INTO `sys_sigin_log` VALUES ('47', '::1', null, 'admin', '系统管理员', null, '2017-05-21 22:10:21');
INSERT INTO `sys_sigin_log` VALUES ('48', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-22 09:08:54');
INSERT INTO `sys_sigin_log` VALUES ('49', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-22 14:47:24');
INSERT INTO `sys_sigin_log` VALUES ('50', '::1', '36.149.203.34', 'admin', '系统管理员', '江苏省常州市', '2017-05-22 21:13:26');
INSERT INTO `sys_sigin_log` VALUES ('51', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-23 09:03:16');
INSERT INTO `sys_sigin_log` VALUES ('52', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-23 12:55:29');
INSERT INTO `sys_sigin_log` VALUES ('53', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-23 14:27:55');
INSERT INTO `sys_sigin_log` VALUES ('54', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-24 13:11:00');
INSERT INTO `sys_sigin_log` VALUES ('55', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-24 16:44:50');
INSERT INTO `sys_sigin_log` VALUES ('56', '::1', '36.149.10.187', 'admin', '系统管理员', '江苏省常州市', '2017-05-24 20:58:46');
INSERT INTO `sys_sigin_log` VALUES ('57', '::1', '36.149.10.187', 'admin', '系统管理员', '江苏省常州市', '2017-05-24 21:15:44');
INSERT INTO `sys_sigin_log` VALUES ('58', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 08:21:29');
INSERT INTO `sys_sigin_log` VALUES ('59', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 09:43:47');
INSERT INTO `sys_sigin_log` VALUES ('60', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 13:23:04');
INSERT INTO `sys_sigin_log` VALUES ('61', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 14:17:38');
INSERT INTO `sys_sigin_log` VALUES ('62', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 15:06:01');
INSERT INTO `sys_sigin_log` VALUES ('63', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 15:12:53');
INSERT INTO `sys_sigin_log` VALUES ('64', '::1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 15:15:36');
INSERT INTO `sys_sigin_log` VALUES ('65', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 15:17:30');
INSERT INTO `sys_sigin_log` VALUES ('66', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-25 16:21:48');
INSERT INTO `sys_sigin_log` VALUES ('67', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-26 09:15:09');
INSERT INTO `sys_sigin_log` VALUES ('68', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-26 12:06:57');
INSERT INTO `sys_sigin_log` VALUES ('69', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-26 14:41:41');
INSERT INTO `sys_sigin_log` VALUES ('70', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-26 16:56:41');
INSERT INTO `sys_sigin_log` VALUES ('71', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-26 17:00:40');
INSERT INTO `sys_sigin_log` VALUES ('72', '127.0.0.1', '36.149.137.180', 'admin', '系统管理员', '江苏省常州市', '2017-05-26 21:08:16');
INSERT INTO `sys_sigin_log` VALUES ('73', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-27 09:29:53');
INSERT INTO `sys_sigin_log` VALUES ('74', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-27 12:59:44');
INSERT INTO `sys_sigin_log` VALUES ('75', '127.0.0.1', '202.102.102.67', 'admin1', '测试账号1', '江苏省南京市', '2017-05-27 14:36:25');
INSERT INTO `sys_sigin_log` VALUES ('76', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-27 14:37:45');
INSERT INTO `sys_sigin_log` VALUES ('77', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-27 14:41:35');
INSERT INTO `sys_sigin_log` VALUES ('78', '127.0.0.1', '202.102.102.67', 'admin1', '测试账号1', '江苏省南京市', '2017-05-27 14:44:28');
INSERT INTO `sys_sigin_log` VALUES ('79', '127.0.0.1', '202.102.102.67', 'admin1', '测试账号1', '江苏省南京市', '2017-05-27 15:43:12');
INSERT INTO `sys_sigin_log` VALUES ('80', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-27 15:50:21');
INSERT INTO `sys_sigin_log` VALUES ('81', '127.0.0.1', '202.102.102.67', 'admin1', '测试账号1', '江苏省南京市', '2017-05-27 16:30:43');
INSERT INTO `sys_sigin_log` VALUES ('82', '127.0.0.1', '202.102.102.67', 'admin2', '测试账号2', '江苏省南京市', '2017-05-27 16:45:47');
INSERT INTO `sys_sigin_log` VALUES ('83', '127.0.0.1', '36.149.138.226', 'admin1', '测试账号1', '江苏省常州市', '2017-05-29 10:33:23');
INSERT INTO `sys_sigin_log` VALUES ('84', '127.0.0.1', '36.149.138.226', 'admin1', '测试账号1', '江苏省常州市', '2017-05-29 10:59:03');
INSERT INTO `sys_sigin_log` VALUES ('85', '127.0.0.1', '36.149.138.226', 'admin7', '测试账号7', '江苏省常州市', '2017-05-29 11:03:47');
INSERT INTO `sys_sigin_log` VALUES ('86', '127.0.0.1', '36.149.138.226', 'admin1', '测试账号1', '江苏省常州市', '2017-05-29 11:05:56');
INSERT INTO `sys_sigin_log` VALUES ('87', '127.0.0.1', '36.149.138.226', 'admin7', '测试账号7', '江苏省常州市', '2017-05-29 11:07:16');
INSERT INTO `sys_sigin_log` VALUES ('88', '127.0.0.1', '36.149.138.226', 'admin1', '测试账号1', '江苏省常州市', '2017-05-29 11:18:00');
INSERT INTO `sys_sigin_log` VALUES ('89', '127.0.0.1', '36.149.138.226', 'admin7', '测试账号7', '江苏省常州市', '2017-05-29 11:27:13');
INSERT INTO `sys_sigin_log` VALUES ('90', '127.0.0.1', '36.149.138.226', 'admin7', '测试账号7', '江苏省常州市', '2017-05-29 11:30:13');
INSERT INTO `sys_sigin_log` VALUES ('91', '127.0.0.1', '36.149.138.226', 'admin7', '测试账号7', '江苏省常州市', '2017-05-29 11:33:49');
INSERT INTO `sys_sigin_log` VALUES ('92', '127.0.0.1', '36.149.138.226', 'admin7', '测试账号7', '江苏省常州市', '2017-05-29 20:00:00');
INSERT INTO `sys_sigin_log` VALUES ('93', '127.0.0.1', '36.149.138.226', 'admin3', '测试账号3', '江苏省常州市', '2017-05-29 20:55:47');
INSERT INTO `sys_sigin_log` VALUES ('94', '127.0.0.1', '36.149.138.226', 'admin4', '测试账号4', '江苏省常州市', '2017-05-29 21:31:37');
INSERT INTO `sys_sigin_log` VALUES ('95', '127.0.0.1', '36.149.138.226', 'admin1', '测试账号1', '江苏省常州市', '2017-05-29 21:40:42');
INSERT INTO `sys_sigin_log` VALUES ('96', '127.0.0.1', '36.149.138.226', 'admin', '系统管理员', '江苏省常州市', '2017-05-29 22:12:47');
INSERT INTO `sys_sigin_log` VALUES ('97', '127.0.0.1', '36.149.8.60', 'admin1', '测试账号1', '江苏省常州市', '2017-05-29 22:26:01');
INSERT INTO `sys_sigin_log` VALUES ('98', '127.0.0.1', '36.149.8.60', 'admin', '系统管理员', '江苏省常州市', '2017-05-29 23:01:32');
INSERT INTO `sys_sigin_log` VALUES ('99', '127.0.0.1', '36.149.8.60', 'admin', '系统管理员', '江苏省常州市', '2017-05-29 23:09:33');
INSERT INTO `sys_sigin_log` VALUES ('100', '127.0.0.1', '36.149.8.60', 'admin', '系统管理员', '江苏省常州市', '2017-05-30 10:41:04');
INSERT INTO `sys_sigin_log` VALUES ('101', '127.0.0.1', '36.149.8.60', 'admin', '系统管理员', '江苏省常州市', '2017-05-30 21:31:23');
INSERT INTO `sys_sigin_log` VALUES ('102', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-31 08:22:13');
INSERT INTO `sys_sigin_log` VALUES ('103', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-05-31 15:00:59');
INSERT INTO `sys_sigin_log` VALUES ('104', '192.168.232.104', '36.149.8.168', 'admin', '系统管理员', '江苏省常州市', '2017-05-31 22:46:38');
INSERT INTO `sys_sigin_log` VALUES ('105', '192.168.232.104', '36.149.8.168', 'admin', '系统管理员', '江苏省常州市', '2017-05-31 22:48:08');
INSERT INTO `sys_sigin_log` VALUES ('106', '192.168.232.104', '36.149.8.168', 'admin', '系统管理员', '江苏省常州市', '2017-05-31 22:50:12');
INSERT INTO `sys_sigin_log` VALUES ('107', '127.0.0.1', '36.149.202.131', 'admin', '系统管理员', '江苏省常州市', '2017-06-04 23:09:28');
INSERT INTO `sys_sigin_log` VALUES ('108', '127.0.0.1', '36.149.202.131', 'admin', '系统管理员', '江苏省常州市', '2017-06-04 23:09:28');
INSERT INTO `sys_sigin_log` VALUES ('109', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-06-05 14:02:59');
INSERT INTO `sys_sigin_log` VALUES ('110', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-06-05 14:03:41');
INSERT INTO `sys_sigin_log` VALUES ('111', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-06-05 14:45:36');
INSERT INTO `sys_sigin_log` VALUES ('112', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-06-05 15:09:26');
INSERT INTO `sys_sigin_log` VALUES ('113', '127.0.0.1', '202.102.102.67', 'admin', '系统管理员', '江苏省南京市', '2017-06-05 15:31:41');
INSERT INTO `sys_sigin_log` VALUES ('114', '127.0.0.1', '36.149.137.86', 'admin', '系统管理员', '江苏省常州市', null);
INSERT INTO `sys_sigin_log` VALUES ('115', '127.0.0.1', '36.149.137.86', 'admin', '系统管理员', '江苏省常州市', null);
INSERT INTO `sys_sigin_log` VALUES ('116', '127.0.0.1', '36.149.137.86', 'admin', '系统管理员', '江苏省常州市', null);
INSERT INTO `sys_sigin_log` VALUES ('117', '127.0.0.1', '36.149.137.86', 'admin', '系统管理员', '江苏省常州市', null);
INSERT INTO `sys_sigin_log` VALUES ('118', '127.0.0.1', '36.149.200.173', 'admin', '系统管理员', '江苏省常州市', null);

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `USER_ID` varchar(30) NOT NULL,
  `USER_NAME` varchar(50) DEFAULT NULL,
  `USER_PWD` varchar(50) DEFAULT NULL,
  `USER_EMAIL` varchar(50) DEFAULT NULL,
  `USER_MOBILE` varchar(50) DEFAULT NULL,
  `IS_ENABLE` decimal(1,0) DEFAULT NULL,
  `IS_ADMIN` decimal(1,0) DEFAULT NULL,
  `DATE_LOGINLAST` datetime DEFAULT NULL,
  `JSON_CONFIG` varchar(200) DEFAULT NULL,
  `USER_SEX` varchar(10) DEFAULT NULL,
  `USER_ADDRESS` varchar(200) DEFAULT NULL,
  `CREATER_ID` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`USER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('100', '陈力', 'e10adc3949ba59abbe56e057f20f883e', '273168121@qq.com', '18663316818', '0', '0', null, null, '0', '山东日照', 'admin');
INSERT INTO `sys_user` VALUES ('200', '测试用户', 'e10adc3949ba59abbe56e057f20f883e', '测试用户@163.com', '1212', '0', '0', null, null, '0', '121212', 'admin');
INSERT INTO `sys_user` VALUES ('300', '1212', 'e10adc3949ba59abbe56e057f20f883e', '121212@163.com', '121212', '0', '0', null, null, '0', '121212', 'admin');
INSERT INTO `sys_user` VALUES ('admin', '系统管理员', 'e10adc3949ba59abbe56e057f20f883e', '273168121@qq.com', '121313', '0', '1', '2017-03-10 00:00:00', null, '0', '安徽', 'NULL');
INSERT INTO `sys_user` VALUES ('admin1', '测试账号1', 'e10adc3949ba59abbe56e057f20f883e', '11@163.com', '13000000', '0', '0', '2017-03-11 01:00:00', null, '0', '安徽', 'NULL');
INSERT INTO `sys_user` VALUES ('admin2', '测试账号2', 'e10adc3949ba59abbe56e057f20f883e', '11@163.com', '13000000', '0', '0', '2017-03-12 02:00:00', null, '0', '安徽', 'NULL');
INSERT INTO `sys_user` VALUES ('admin3', '测试账号3', 'e10adc3949ba59abbe56e057f20f883e', '11@163.com', '13000000', '0', '0', '2017-03-13 03:00:00', null, '1', '安徽', 'NULL');
INSERT INTO `sys_user` VALUES ('admin4', '测试账号4', 'e10adc3949ba59abbe56e057f20f883e', '11@163.com', '13000000', '0', '0', '2017-03-14 04:00:00', null, '1', '安徽', 'NULL');
INSERT INTO `sys_user` VALUES ('admin5', '测试账号5', 'e10adc3949ba59abbe56e057f20f883e', '11@163.com', '13000000', '0', '0', '2017-03-15 05:00:00', null, '0', '安徽', 'NULL');
INSERT INTO `sys_user` VALUES ('admin6', '测试账号6', 'e10adc3949ba59abbe56e057f20f883e', '11@163.com', '13000000', '0', '0', '2017-03-16 06:00:00', null, '0', '安徽', 'NULL');
INSERT INTO `sys_user` VALUES ('admin7', '测试账号7', 'e10adc3949ba59abbe56e057f20f883e', '11@163.com', '13000000', '0', '0', '2017-03-17 07:00:00', null, '1', '安徽', 'NULL');

-- ----------------------------
-- Table structure for sys_user_department
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_department`;
CREATE TABLE `sys_user_department` (
  `USER_ID` varchar(50) NOT NULL,
  `DEPARTMENT_ID` varchar(50) NOT NULL,
  PRIMARY KEY (`USER_ID`,`DEPARTMENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_department
-- ----------------------------
INSERT INTO `sys_user_department` VALUES ('100', 'JT02');
INSERT INTO `sys_user_department` VALUES ('admin', 'JT01');
INSERT INTO `sys_user_department` VALUES ('admin1', 'JT01');
INSERT INTO `sys_user_department` VALUES ('admin2', 'JT');
INSERT INTO `sys_user_department` VALUES ('admin4', 'JT');
INSERT INTO `sys_user_department` VALUES ('admin5', 'JT01');
INSERT INTO `sys_user_department` VALUES ('admin6', 'JT01');
INSERT INTO `sys_user_department` VALUES ('admin7', 'JT03');

-- ----------------------------
-- Table structure for sys_user_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_role`;
CREATE TABLE `sys_user_role` (
  `USER_ID` varchar(50) NOT NULL,
  `ROLE_ID` varchar(20) NOT NULL,
  PRIMARY KEY (`USER_ID`,`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_role
-- ----------------------------
INSERT INTO `sys_user_role` VALUES ('100', 'R001');
INSERT INTO `sys_user_role` VALUES ('admin1', 'R001');
INSERT INTO `sys_user_role` VALUES ('admin4', 'R003');
INSERT INTO `sys_user_role` VALUES ('admin5', 'R003');
INSERT INTO `sys_user_role` VALUES ('admin7', 'R005');
