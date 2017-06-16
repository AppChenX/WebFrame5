/*
Navicat SQL Server Data Transfer

Source Server         : sqlserver
Source Server Version : 100000
Source Host           : Chenl-pc:1433
Source Database       : Permission
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 100000
File Encoding         : 65001

Date: 2017-06-16 07:53:23
*/


-- ----------------------------
-- Table structure for Sys_Action
-- ----------------------------
DROP TABLE [dbo].[Sys_Action]
GO
CREATE TABLE [dbo].[Sys_Action] (
[Action_Id] nvarchar(20) NOT NULL ,
[Menu_Id] nvarchar(20) NULL ,
[Action_Name] nvarchar(50) NULL ,
[Action_Url] nvarchar(200) NULL ,
[Action_IconClass] nvarchar(50) NULL ,
[Action_IconUrl] nvarchar(150) NULL ,
[Action_BId] nvarchar(50) NULL 
)


GO

-- ----------------------------
-- Records of Sys_Action
-- ----------------------------
INSERT INTO [dbo].[Sys_Action] ([Action_Id], [Menu_Id], [Action_Name], [Action_Url], [Action_IconClass], [Action_IconUrl], [Action_BId]) VALUES (N'12', N'M001001', N'测试1', N'api/test1', N'iconCls', null, null)
GO
GO
INSERT INTO [dbo].[Sys_Action] ([Action_Id], [Menu_Id], [Action_Name], [Action_Url], [Action_IconClass], [Action_IconUrl], [Action_BId]) VALUES (N'13', N'M001001', N'测试2', N'api/test2', N'iconCls', null, null)
GO
GO
INSERT INTO [dbo].[Sys_Action] ([Action_Id], [Menu_Id], [Action_Name], [Action_Url], [Action_IconClass], [Action_IconUrl], [Action_BId]) VALUES (N'14', N'M001001', N'测试2', N'api/test2', N'iconCls', null, null)
GO
GO
INSERT INTO [dbo].[Sys_Action] ([Action_Id], [Menu_Id], [Action_Name], [Action_Url], [Action_IconClass], [Action_IconUrl], [Action_BId]) VALUES (N'B001', N'M001002', N'测试1', N'12', N'iconCls', null, null)
GO
GO

-- ----------------------------
-- Table structure for Sys_Department
-- ----------------------------
DROP TABLE [dbo].[Sys_Department]
GO
CREATE TABLE [dbo].[Sys_Department] (
[Department_Id] nvarchar(50) NOT NULL ,
[Department_Name] nvarchar(50) NULL ,
[Department_PId] nvarchar(50) NULL 
)


GO

-- ----------------------------
-- Records of Sys_Department
-- ----------------------------
INSERT INTO [dbo].[Sys_Department] ([Department_Id], [Department_Name], [Department_PId]) VALUES (N'JT', N'中南海', N'0')
GO
GO
INSERT INTO [dbo].[Sys_Department] ([Department_Id], [Department_Name], [Department_PId]) VALUES (N'JT01', N'中国电力公司', N'JT')
GO
GO
INSERT INTO [dbo].[Sys_Department] ([Department_Id], [Department_Name], [Department_PId]) VALUES (N'JT0101', N'南方电网', N'JT01')
GO
GO
INSERT INTO [dbo].[Sys_Department] ([Department_Id], [Department_Name], [Department_PId]) VALUES (N'JT0102', N'北京电网', N'JT01')
GO
GO
INSERT INTO [dbo].[Sys_Department] ([Department_Id], [Department_Name], [Department_PId]) VALUES (N'JT02', N'中国北方公司', N'JT')
GO
GO
INSERT INTO [dbo].[Sys_Department] ([Department_Id], [Department_Name], [Department_PId]) VALUES (N'JT03', N'中国石化', N'JT')
GO
GO

-- ----------------------------
-- Table structure for Sys_Menu
-- ----------------------------
DROP TABLE [dbo].[Sys_Menu]
GO
CREATE TABLE [dbo].[Sys_Menu] (
[Menu_Id] nvarchar(50) NOT NULL ,
[Menu_PID] nvarchar(50) NULL ,
[Menu_Url] nvarchar(50) NULL ,
[Menu_Name] nvarchar(50) NULL ,
[Menu_IconUrl] nvarchar(150) NULL ,
[Menu_IconClass] nvarchar(50) NULL ,
[Menu_Seq] int NOT NULL ,
[Is_Enable] bit NULL ,
[Date_Create] datetime NULL 
)


GO

-- ----------------------------
-- Records of Sys_Menu
-- ----------------------------
INSERT INTO [dbo].[Sys_Menu] ([Menu_Id], [Menu_PID], [Menu_Url], [Menu_Name], [Menu_IconUrl], [Menu_IconClass], [Menu_Seq], [Is_Enable], [Date_Create]) VALUES (N'M001', N'0', N'', N'系统管理', N'', N'icon-computer', N'0', N'0', N'2017-03-11 00:00:00.000')
GO
GO
INSERT INTO [dbo].[Sys_Menu] ([Menu_Id], [Menu_PID], [Menu_Url], [Menu_Name], [Menu_IconUrl], [Menu_IconClass], [Menu_Seq], [Is_Enable], [Date_Create]) VALUES (N'M001001', N'M001', N'/Sys/SysUser/Index', N'用户管理', N'/Content/Images/icons/user.png', N'icon-user', N'1', N'0', N'2017-03-11 12:00:00.000')
GO
GO
INSERT INTO [dbo].[Sys_Menu] ([Menu_Id], [Menu_PID], [Menu_Url], [Menu_Name], [Menu_IconUrl], [Menu_IconClass], [Menu_Seq], [Is_Enable], [Date_Create]) VALUES (N'M001002', N'M001', N'/Sys/SysMenu/Index', N'菜单管理', N'/Content/Images/icons/application_view_columns.png', N'icon-application_view_columns', N'2', N'0', N'2017-03-11 12:00:00.000')
GO
GO
INSERT INTO [dbo].[Sys_Menu] ([Menu_Id], [Menu_PID], [Menu_Url], [Menu_Name], [Menu_IconUrl], [Menu_IconClass], [Menu_Seq], [Is_Enable], [Date_Create]) VALUES (N'M002', N'M001', N'/Sys/SysLog/Index', N'系统日志', N'/Content/Images/icons/page_white_text.png', N'icon-page_white_text', N'5', N'1', N'2017-03-12 12:02:52.000')
GO
GO
INSERT INTO [dbo].[Sys_Menu] ([Menu_Id], [Menu_PID], [Menu_Url], [Menu_Name], [Menu_IconUrl], [Menu_IconClass], [Menu_Seq], [Is_Enable], [Date_Create]) VALUES (N'M003', N'M001', N'/Sys/SysRole/Index', N'角色管理', N'/Content/Images/icons/user_key.png', N'icon-user_key', N'3', N'0', N'2017-03-12 07:26:45.000')
GO
GO
INSERT INTO [dbo].[Sys_Menu] ([Menu_Id], [Menu_PID], [Menu_Url], [Menu_Name], [Menu_IconUrl], [Menu_IconClass], [Menu_Seq], [Is_Enable], [Date_Create]) VALUES (N'M004', N'M001', N'/Sys/SysDepartment/Index', N'部门管理', N'', N'icon-application_osx_home', N'4', N'0', N'2017-05-20 23:49:02.090')
GO
GO

-- ----------------------------
-- Table structure for sys_ParamConfig
-- ----------------------------
DROP TABLE [dbo].[sys_ParamConfig]
GO
CREATE TABLE [dbo].[sys_ParamConfig] (
[ID] int NOT NULL IDENTITY(1,1) ,
[SPNAME] nvarchar(50) NULL ,
[ArgName] nvarchar(50) NULL ,
[DataType] nvarchar(50) NULL ,
[Direction] nvarchar(50) NULL ,
[Seq] int NULL 
)


GO

-- ----------------------------
-- Records of sys_ParamConfig
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sys_ParamConfig] ON
GO
INSERT INTO [dbo].[sys_ParamConfig] ([ID], [SPNAME], [ArgName], [DataType], [Direction], [Seq]) VALUES (N'1', N'sp_sysUser_query', N'@userId', N'string', N'in', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[sys_ParamConfig] OFF
GO

-- ----------------------------
-- Table structure for Sys_Role
-- ----------------------------
DROP TABLE [dbo].[Sys_Role]
GO
CREATE TABLE [dbo].[Sys_Role] (
[Role_Id] nvarchar(20) NOT NULL ,
[Role_Name] nvarchar(50) NULL ,
[Role_Desc] nvarchar(200) NULL ,
[Creator] nvarchar(50) NULL 
)


GO

-- ----------------------------
-- Records of Sys_Role
-- ----------------------------
INSERT INTO [dbo].[Sys_Role] ([Role_Id], [Role_Name], [Role_Desc], [Creator]) VALUES (N'121212', N'测试', N'测试2111', null)
GO
GO
INSERT INTO [dbo].[Sys_Role] ([Role_Id], [Role_Name], [Role_Desc], [Creator]) VALUES (N'R001', N'测试角色', N'测试角色11', null)
GO
GO
INSERT INTO [dbo].[Sys_Role] ([Role_Id], [Role_Name], [Role_Desc], [Creator]) VALUES (N'R002', N'一炼钢操作员', N'测试角色11', null)
GO
GO
INSERT INTO [dbo].[Sys_Role] ([Role_Id], [Role_Name], [Role_Desc], [Creator]) VALUES (N'R003', N'管理员1', N'管理员1', null)
GO
GO
INSERT INTO [dbo].[Sys_Role] ([Role_Id], [Role_Name], [Role_Desc], [Creator]) VALUES (N'R005', N'R005', N'R005', null)
GO
GO
INSERT INTO [dbo].[Sys_Role] ([Role_Id], [Role_Name], [Role_Desc], [Creator]) VALUES (N'R006', N'R006', N'R006', null)
GO
GO
INSERT INTO [dbo].[Sys_Role] ([Role_Id], [Role_Name], [Role_Desc], [Creator]) VALUES (N'R007', N'R007', N'R007', null)
GO
GO

-- ----------------------------
-- Table structure for Sys_Role_Action
-- ----------------------------
DROP TABLE [dbo].[Sys_Role_Action]
GO
CREATE TABLE [dbo].[Sys_Role_Action] (
[Role_Id] nvarchar(20) NOT NULL ,
[Action_Id] nvarchar(20) NOT NULL 
)


GO

-- ----------------------------
-- Records of Sys_Role_Action
-- ----------------------------
INSERT INTO [dbo].[Sys_Role_Action] ([Role_Id], [Action_Id]) VALUES (N'R001', N'12')
GO
GO
INSERT INTO [dbo].[Sys_Role_Action] ([Role_Id], [Action_Id]) VALUES (N'R001', N'13')
GO
GO
INSERT INTO [dbo].[Sys_Role_Action] ([Role_Id], [Action_Id]) VALUES (N'R001', N'14')
GO
GO
INSERT INTO [dbo].[Sys_Role_Action] ([Role_Id], [Action_Id]) VALUES (N'R003', N'12')
GO
GO
INSERT INTO [dbo].[Sys_Role_Action] ([Role_Id], [Action_Id]) VALUES (N'R003', N'13')
GO
GO
INSERT INTO [dbo].[Sys_Role_Action] ([Role_Id], [Action_Id]) VALUES (N'R003', N'14')
GO
GO
INSERT INTO [dbo].[Sys_Role_Action] ([Role_Id], [Action_Id]) VALUES (N'R003', N'B001')
GO
GO

-- ----------------------------
-- Table structure for Sys_Role_Member
-- ----------------------------
DROP TABLE [dbo].[Sys_Role_Member]
GO
CREATE TABLE [dbo].[Sys_Role_Member] (
[Role_Id] nvarchar(50) NOT NULL ,
[Role_PID] nvarchar(50) NOT NULL ,
[Creator] nvarchar(50) NULL 
)


GO

-- ----------------------------
-- Records of Sys_Role_Member
-- ----------------------------
INSERT INTO [dbo].[Sys_Role_Member] ([Role_Id], [Role_PID], [Creator]) VALUES (N'R001', N'0', N'admin1')
GO
GO
INSERT INTO [dbo].[Sys_Role_Member] ([Role_Id], [Role_PID], [Creator]) VALUES (N'R002', N'R001', null)
GO
GO
INSERT INTO [dbo].[Sys_Role_Member] ([Role_Id], [Role_PID], [Creator]) VALUES (N'R003', N'R001', null)
GO
GO
INSERT INTO [dbo].[Sys_Role_Member] ([Role_Id], [Role_PID], [Creator]) VALUES (N'R004', N'R002', null)
GO
GO
INSERT INTO [dbo].[Sys_Role_Member] ([Role_Id], [Role_PID], [Creator]) VALUES (N'R005', N'R003', null)
GO
GO
INSERT INTO [dbo].[Sys_Role_Member] ([Role_Id], [Role_PID], [Creator]) VALUES (N'R006', N'R003', null)
GO
GO

-- ----------------------------
-- Table structure for Sys_Role_Menu
-- ----------------------------
DROP TABLE [dbo].[Sys_Role_Menu]
GO
CREATE TABLE [dbo].[Sys_Role_Menu] (
[Menu_Id] nvarchar(20) NOT NULL ,
[Role_Id] nvarchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of Sys_Role_Menu
-- ----------------------------
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001', N'R001')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001', N'R002')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001', N'R005')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001', N'undefined')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001001', N'R001')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001001', N'R002')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001001', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001001', N'R005')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001001', N'undefined')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001002', N'R001')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001002', N'R002')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001002', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M001002', N'undefined')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M002', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M003', N'R001')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M003', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M003', N'undefined')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'M004', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'R001', N'M001')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'R001', N'M001001')
GO
GO
INSERT INTO [dbo].[Sys_Role_Menu] ([Menu_Id], [Role_Id]) VALUES (N'R001', N'M001002')
GO
GO

-- ----------------------------
-- Table structure for sys_sequence
-- ----------------------------
DROP TABLE [dbo].[sys_sequence]
GO
CREATE TABLE [dbo].[sys_sequence] (
[SEQ_ID] varchar(20) NOT NULL ,
[SEQ_NAME] varchar(50) NULL DEFAULT NULL ,
[C_FORMAT] varchar(20) NULL DEFAULT NULL ,
[C_CURDATE] varchar(255) NULL DEFAULT NULL ,
[N_STEP] int NULL DEFAULT NULL ,
[C_CURVAL] varchar(20) NULL DEFAULT NULL ,
[C_VAL] varchar(50) NULL DEFAULT NULL ,
[C_PADCHAR] varchar(10) NULL DEFAULT NULL ,
[C_PADLEN] int NULL DEFAULT NULL ,
[C_FORMAT_TYPE] varchar(10) NULL DEFAULT NULL ,
[C_PRECHAR] varchar(10) NULL DEFAULT NULL ,
[C_VERSION] numeric(18) NULL 
)


GO

-- ----------------------------
-- Records of sys_sequence
-- ----------------------------
INSERT INTO [dbo].[sys_sequence] ([SEQ_ID], [SEQ_NAME], [C_FORMAT], [C_CURDATE], [N_STEP], [C_CURVAL], [C_VAL], [C_PADCHAR], [C_PADLEN], [C_FORMAT_TYPE], [C_PRECHAR], [C_VERSION]) VALUES (N'SYS_ROLE.ROLE_ID', N'', N'yyMMdd', N'170615', N'1', N'19704', N'GX17061519704', N'0', N'5', N'0', N'GX', N'45793')
GO
GO

-- ----------------------------
-- Table structure for Sys_Setting
-- ----------------------------
DROP TABLE [dbo].[Sys_Setting]
GO
CREATE TABLE [dbo].[Sys_Setting] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Code] nvarchar(50) NULL ,
[Value] nvarchar(120) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Sys_Setting]', RESEED, 5)
GO

-- ----------------------------
-- Records of Sys_Setting
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Sys_Setting] ON
GO
INSERT INTO [dbo].[Sys_Setting] ([Id], [Code], [Value]) VALUES (N'1', N'SYS_NAME', N'测试系统')
GO
GO
INSERT INTO [dbo].[Sys_Setting] ([Id], [Code], [Value]) VALUES (N'2', N'SYS_EMAIL', N'chenl_11@163.com')
GO
GO
INSERT INTO [dbo].[Sys_Setting] ([Id], [Code], [Value]) VALUES (N'3', N'SYS_EMAIL_USER', N'chenl_11')
GO
GO
INSERT INTO [dbo].[Sys_Setting] ([Id], [Code], [Value]) VALUES (N'4', N'SYS_EMAIL_PWD', N'bbls63152')
GO
GO
INSERT INTO [dbo].[Sys_Setting] ([Id], [Code], [Value]) VALUES (N'5', N'SYS_EMAIL_POT', N'MM.163.COM')
GO
GO
SET IDENTITY_INSERT [dbo].[Sys_Setting] OFF
GO

-- ----------------------------
-- Table structure for Sys_Sigin_log
-- ----------------------------
DROP TABLE [dbo].[Sys_Sigin_log]
GO
CREATE TABLE [dbo].[Sys_Sigin_log] (
[LINE_ID] int NOT NULL IDENTITY(1,1) ,
[LOCAL_IP] nvarchar(50) NULL ,
[NET_IP] nvarchar(50) NULL ,
[USER_ID] nvarchar(50) NULL ,
[USER_NAME] nvarchar(50) NULL ,
[LOGIN_ADDRESS] nvarchar(200) NULL ,
[LOGIN_DATE] datetime NULL DEFAULT (getdate()) 
)


GO
DBCC CHECKIDENT(N'[dbo].[Sys_Sigin_log]', RESEED, 118)
GO

-- ----------------------------
-- Records of Sys_Sigin_log
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Sys_Sigin_log] ON
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'13', N'192.168.1.107', N'112.20.190.11', N'admin4', N'测试账号4', N'江苏省淮安市', N'2017-04-21 22:59:05.577')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'14', N'127.0.0.1', N'36.149.227.203', N'admin4', N'测试账号4', N'江苏省淮安市', N'2017-04-21 23:00:19.143')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'15', N'192.168.1.107', N'36.149.227.203', N'admin', N'系统管理员', N'江苏省淮安市', N'2017-04-21 23:02:24.680')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'16', N'192.168.1.102', N'36.149.227.203', N'admin4', N'测试账号4', N'江苏省淮安市', N'2017-04-21 23:03:55.647')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'17', N'192.168.11.144', N'122.195.215.20', N'admin7', N'测试账号7', N'江苏省淮安市', N'2017-04-24 09:44:23.730')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'18', N'192.168.11.144', N'122.195.215.20', N'admin', N'系统管理员', N'江苏省淮安市', N'2017-04-24 14:28:54.830')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'19', N'127.0.0.1', null, N'admin', N'系统管理员', null, N'2017-05-02 12:42:10.160')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'20', N'127.0.0.1', null, N'admin', N'系统管理员', null, N'2017-05-02 12:45:31.903')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'21', N'127.0.0.1', null, N'admin', N'系统管理员', null, N'2017-05-03 08:09:16.327')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'22', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-18 10:04:18.120')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'23', N'192.168.69.6', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-18 14:01:14.130')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'24', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 20:47:00.857')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'25', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 21:13:55.440')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'26', N'::1', N'36.149.139.72', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-18 21:14:55.540')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'27', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 21:17:33.333')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'28', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 21:18:03.210')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'29', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 21:18:33.847')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'30', N'::1', N'36.149.139.72', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-18 21:22:00.317')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'31', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 21:24:27.390')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'32', N'::1', N'36.149.139.72', N'admin2', N'测试账号2', N'江苏省常州市', N'2017-05-18 21:25:04.590')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'33', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 21:28:39.647')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'34', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-18 21:51:55.990')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'35', N'::1', N'36.149.139.72', N'admin3', N'测试账号3', N'江苏省常州市', N'2017-05-18 22:22:24.000')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'36', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-19 08:13:10.117')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'37', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-19 14:28:15.400')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'38', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-19 15:50:29.453')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'39', N'::1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-19 21:48:27.703')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'40', N'127.0.0.1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-19 21:58:47.307')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'41', N'127.0.0.1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-20 09:50:00.953')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'42', N'192.168.232.104', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-20 09:59:03.763')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'43', N'127.0.0.1', N'36.149.139.72', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-20 11:49:08.857')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'44', N'127.0.0.1', N'36.149.200.168', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-20 22:49:44.913')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'45', N'192.168.232.176', N'36.149.200.168', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-21 00:54:00.020')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'46', N'127.0.0.1', N'36.149.200.168', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-21 21:35:26.623')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'47', N'::1', null, N'admin', N'系统管理员', null, N'2017-05-21 22:10:21.300')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'48', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-22 09:08:54.150')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'49', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-22 14:47:24.123')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'50', N'::1', N'36.149.203.34', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-22 21:13:26.200')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'51', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-23 09:03:16.200')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'52', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-23 12:55:29.693')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'53', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-23 14:27:55.250')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'54', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-24 13:11:00.617')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'55', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-24 16:44:50.823')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'56', N'::1', N'36.149.10.187', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-24 20:58:46.263')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'57', N'::1', N'36.149.10.187', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-24 21:15:44.720')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'58', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 08:21:29.483')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'59', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 09:43:47.770')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'60', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 13:23:04.030')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'61', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 14:17:38.807')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'62', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 15:06:01.620')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'63', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 15:12:53.007')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'64', N'::1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 15:15:36.777')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'65', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 15:17:30.787')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'66', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-25 16:21:48.413')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'67', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-26 09:15:09.327')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'68', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-26 12:06:57.623')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'69', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-26 14:41:41.400')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'70', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-26 16:56:41.467')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'71', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-26 17:00:40.130')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'72', N'127.0.0.1', N'36.149.137.180', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-26 21:08:16.533')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'73', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-27 09:29:53.423')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'74', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-27 12:59:44.360')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'75', N'127.0.0.1', N'202.102.102.67', N'admin1', N'测试账号1', N'江苏省南京市', N'2017-05-27 14:36:25.450')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'76', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-27 14:37:45.440')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'77', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-27 14:41:35.067')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'78', N'127.0.0.1', N'202.102.102.67', N'admin1', N'测试账号1', N'江苏省南京市', N'2017-05-27 14:44:28.557')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'79', N'127.0.0.1', N'202.102.102.67', N'admin1', N'测试账号1', N'江苏省南京市', N'2017-05-27 15:43:12.947')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'80', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-27 15:50:21.393')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'81', N'127.0.0.1', N'202.102.102.67', N'admin1', N'测试账号1', N'江苏省南京市', N'2017-05-27 16:30:43.163')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'82', N'127.0.0.1', N'202.102.102.67', N'admin2', N'测试账号2', N'江苏省南京市', N'2017-05-27 16:45:47.167')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'83', N'127.0.0.1', N'36.149.138.226', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-29 10:33:23.950')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'84', N'127.0.0.1', N'36.149.138.226', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-29 10:59:03.027')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'85', N'127.0.0.1', N'36.149.138.226', N'admin7', N'测试账号7', N'江苏省常州市', N'2017-05-29 11:03:47.963')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'86', N'127.0.0.1', N'36.149.138.226', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-29 11:05:56.420')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'87', N'127.0.0.1', N'36.149.138.226', N'admin7', N'测试账号7', N'江苏省常州市', N'2017-05-29 11:07:16.207')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'88', N'127.0.0.1', N'36.149.138.226', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-29 11:18:00.973')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'89', N'127.0.0.1', N'36.149.138.226', N'admin7', N'测试账号7', N'江苏省常州市', N'2017-05-29 11:27:13.453')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'90', N'127.0.0.1', N'36.149.138.226', N'admin7', N'测试账号7', N'江苏省常州市', N'2017-05-29 11:30:13.333')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'91', N'127.0.0.1', N'36.149.138.226', N'admin7', N'测试账号7', N'江苏省常州市', N'2017-05-29 11:33:49.380')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'92', N'127.0.0.1', N'36.149.138.226', N'admin7', N'测试账号7', N'江苏省常州市', N'2017-05-29 20:00:00.070')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'93', N'127.0.0.1', N'36.149.138.226', N'admin3', N'测试账号3', N'江苏省常州市', N'2017-05-29 20:55:47.903')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'94', N'127.0.0.1', N'36.149.138.226', N'admin4', N'测试账号4', N'江苏省常州市', N'2017-05-29 21:31:37.587')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'95', N'127.0.0.1', N'36.149.138.226', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-29 21:40:42.187')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'96', N'127.0.0.1', N'36.149.138.226', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-29 22:12:47.370')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'97', N'127.0.0.1', N'36.149.8.60', N'admin1', N'测试账号1', N'江苏省常州市', N'2017-05-29 22:26:01.600')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'98', N'127.0.0.1', N'36.149.8.60', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-29 23:01:32.970')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'99', N'127.0.0.1', N'36.149.8.60', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-29 23:09:33.927')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'100', N'127.0.0.1', N'36.149.8.60', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-30 10:41:04.930')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'101', N'127.0.0.1', N'36.149.8.60', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-30 21:31:23.570')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'102', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-31 08:22:13.303')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'103', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-05-31 15:00:59.190')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'104', N'192.168.232.104', N'36.149.8.168', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-31 22:46:38.060')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'105', N'192.168.232.104', N'36.149.8.168', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-31 22:48:08.227')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'106', N'192.168.232.104', N'36.149.8.168', N'admin', N'系统管理员', N'江苏省常州市', N'2017-05-31 22:50:12.367')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'107', N'127.0.0.1', N'36.149.202.131', N'admin', N'系统管理员', N'江苏省常州市', N'2017-06-04 23:09:28.427')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'108', N'127.0.0.1', N'36.149.202.131', N'admin', N'系统管理员', N'江苏省常州市', N'2017-06-04 23:09:28.427')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'109', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-06-05 14:02:59.780')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'110', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-06-05 14:03:41.737')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'111', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-06-05 14:45:36.730')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'112', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-06-05 15:09:26.150')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'113', N'127.0.0.1', N'202.102.102.67', N'admin', N'系统管理员', N'江苏省南京市', N'2017-06-05 15:31:41.210')
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'114', N'127.0.0.1', N'36.149.137.86', N'admin', N'系统管理员', N'江苏省常州市', null)
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'115', N'127.0.0.1', N'36.149.137.86', N'admin', N'系统管理员', N'江苏省常州市', null)
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'116', N'127.0.0.1', N'36.149.137.86', N'admin', N'系统管理员', N'江苏省常州市', null)
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'117', N'127.0.0.1', N'36.149.137.86', N'admin', N'系统管理员', N'江苏省常州市', null)
GO
GO
INSERT INTO [dbo].[Sys_Sigin_log] ([LINE_ID], [LOCAL_IP], [NET_IP], [USER_ID], [USER_NAME], [LOGIN_ADDRESS], [LOGIN_DATE]) VALUES (N'118', N'127.0.0.1', N'36.149.200.173', N'admin', N'系统管理员', N'江苏省常州市', null)
GO
GO
SET IDENTITY_INSERT [dbo].[Sys_Sigin_log] OFF
GO

-- ----------------------------
-- Table structure for Sys_User
-- ----------------------------
DROP TABLE [dbo].[Sys_User]
GO
CREATE TABLE [dbo].[Sys_User] (
[User_Id] nvarchar(128) NOT NULL ,
[User_Name] nvarchar(MAX) NULL ,
[User_Pwd] nvarchar(MAX) NULL ,
[User_Email] nvarchar(MAX) NULL ,
[User_Mobile] nvarchar(MAX) NULL ,
[Is_Enable] bit NOT NULL ,
[Is_Admin] bit NULL DEFAULT ((0)) ,
[Date_LoginLast] datetime NULL ,
[Json_Config] nvarchar(MAX) NULL ,
[User_Sex] nvarchar(MAX) NULL ,
[User_Address] nvarchar(MAX) NULL ,
[Creater_ID] nvarchar(MAX) NULL 
)


GO

-- ----------------------------
-- Records of Sys_User
-- ----------------------------
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'100', N'陈力', N'e10adc3949ba59abbe56e057f20f883e', N'273168121@qq.com', N'18663316818', N'0', N'0', null, null, N'0', N'山东日照', N'admin')
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'200', N'测试用户', N'e10adc3949ba59abbe56e057f20f883e', N'测试用户@163.com', N'1212', N'0', N'0', null, null, N'0', N'121212', N'admin')
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'300', N'1212', N'e10adc3949ba59abbe56e057f20f883e', N'121212@163.com', N'121212', N'0', N'0', null, null, N'0', N'121212', N'admin')
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin', N'系统管理员', N'e10adc3949ba59abbe56e057f20f883e', N'273168121@qq.com', N'121313', N'0', N'1', N'2017-03-10 00:00:00.000', null, N'0', N'安徽', null)
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin1', N'测试账号1', N'e10adc3949ba59abbe56e057f20f883e', N'11@163.com', N'13000000', N'0', N'0', N'2017-03-11 01:00:00.000', null, N'0', N'安徽', null)
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin2', N'测试账号2', N'e10adc3949ba59abbe56e057f20f883e', N'11@163.com', N'13000000', N'0', N'0', N'2017-03-12 02:00:00.000', null, N'0', N'安徽', null)
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin3', N'测试账号3', N'e10adc3949ba59abbe56e057f20f883e', N'11@163.com', N'13000000', N'0', N'0', N'2017-03-13 03:00:00.000', null, N'1', N'安徽', null)
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin4', N'测试账号4', N'e10adc3949ba59abbe56e057f20f883e', N'11@163.com', N'13000000', N'0', N'0', N'2017-03-14 04:00:00.000', null, N'1', N'安徽', null)
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin5', N'测试账号5', N'e10adc3949ba59abbe56e057f20f883e', N'11@163.com', N'13000000', N'0', N'0', N'2017-03-15 05:00:00.000', null, N'0', N'安徽', null)
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin6', N'测试账号6', N'e10adc3949ba59abbe56e057f20f883e', N'11@163.com', N'13000000', N'0', N'0', N'2017-03-16 06:00:00.000', null, N'0', N'安徽', null)
GO
GO
INSERT INTO [dbo].[Sys_User] ([User_Id], [User_Name], [User_Pwd], [User_Email], [User_Mobile], [Is_Enable], [Is_Admin], [Date_LoginLast], [Json_Config], [User_Sex], [User_Address], [Creater_ID]) VALUES (N'admin7', N'测试账号7', N'e10adc3949ba59abbe56e057f20f883e', N'11@163.com', N'13000000', N'0', N'0', N'2017-03-17 07:00:00.000', null, N'1', N'安徽', null)
GO
GO

-- ----------------------------
-- Table structure for Sys_User_Department
-- ----------------------------
DROP TABLE [dbo].[Sys_User_Department]
GO
CREATE TABLE [dbo].[Sys_User_Department] (
[User_id] nvarchar(50) NOT NULL ,
[Department_id] nvarchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of Sys_User_Department
-- ----------------------------
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'100', N'JT02')
GO
GO
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'admin', N'JT01')
GO
GO
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'admin1', N'JT01')
GO
GO
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'admin2', N'JT')
GO
GO
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'admin4', N'JT')
GO
GO
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'admin5', N'JT01')
GO
GO
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'admin6', N'JT01')
GO
GO
INSERT INTO [dbo].[Sys_User_Department] ([User_id], [Department_id]) VALUES (N'admin7', N'JT03')
GO
GO

-- ----------------------------
-- Table structure for Sys_User_Role
-- ----------------------------
DROP TABLE [dbo].[Sys_User_Role]
GO
CREATE TABLE [dbo].[Sys_User_Role] (
[User_Id] nvarchar(50) NOT NULL ,
[Role_Id] nvarchar(20) NOT NULL 
)


GO

-- ----------------------------
-- Records of Sys_User_Role
-- ----------------------------
INSERT INTO [dbo].[Sys_User_Role] ([User_Id], [Role_Id]) VALUES (N'100', N'R001')
GO
GO
INSERT INTO [dbo].[Sys_User_Role] ([User_Id], [Role_Id]) VALUES (N'100', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_User_Role] ([User_Id], [Role_Id]) VALUES (N'admin1', N'R001')
GO
GO
INSERT INTO [dbo].[Sys_User_Role] ([User_Id], [Role_Id]) VALUES (N'admin4', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_User_Role] ([User_Id], [Role_Id]) VALUES (N'admin5', N'R003')
GO
GO
INSERT INTO [dbo].[Sys_User_Role] ([User_Id], [Role_Id]) VALUES (N'admin7', N'R005')
GO
GO

-- ----------------------------
-- Procedure structure for sp_sysUser_query
-- ----------------------------
DROP PROCEDURE [dbo].[sp_sysUser_query]
GO
CREATE procedure [dbo].[sp_sysUser_query]  @userId varchar(20)
as
begin

  SELECT T.* FROM dbo.Sys_User T WHERE T.UserId=@userId;

end;
GO

-- ----------------------------
-- Procedure structure for sys_Page_v2
-- ----------------------------
DROP PROCEDURE [dbo].[sys_Page_v2]
GO
CREATE PROCEDURE [dbo].[sys_Page_v2]  
@PCount int output,    --总页数输出  
@RCount int output,    --总记录数输出  
@sys_Table nvarchar(100),    --查询表名  
@sys_Key varchar(50),        --主键  
@sys_Fields nvarchar(500),    --查询字段  
@sys_Where nvarchar(3000),    --查询条件  
@sys_Order nvarchar(100),    --排序字段  
@sys_Begin int,        --开始位置  
@sys_PageIndex int,        --当前页数  
@sys_PageSize int        --页大小  
AS  
SET NOCOUNT ON  
SET ANSI_WARNINGS ON  
IF @sys_PageSize < 0 OR @sys_PageIndex < 0  
BEGIN          
RETURN  
END  
DECLARE @new_where1 NVARCHAR(3000)  
DECLARE @new_order1 NVARCHAR(100)  
DECLARE @new_order2 NVARCHAR(100)  
DECLARE @Sql NVARCHAR(4000)  
DECLARE @SqlCount NVARCHAR(4000)  
DECLARE @Top int  
if(@sys_Begin <=0)  
    set @sys_Begin=0  
else  
    set @sys_Begin=@sys_Begin-1  
IF ISNULL(@sys_Where,'') = ''  
    SET @new_where1 = ' '  
ELSE  
    SET @new_where1 = ' WHERE ' + @sys_Where  
IF ISNULL(@sys_Order,'') <> ''   
BEGIN  
    SET @new_order1 = ' ORDER BY ' + Replace(@sys_Order,'desc','')  
    SET @new_order1 = Replace(@new_order1,'asc','desc')  
    SET @new_order2 = ' ORDER BY ' + @sys_Order  
END  
ELSE  
BEGIN  
    SET @new_order1 = ' ORDER BY ID DESC'  
    SET @new_order2 = ' ORDER BY ID ASC'  
END  
SET @SqlCount = 'SELECT @RCount=COUNT(1),@PCount=CEILING((COUNT(1)+0.0)/'  
            + CAST(@sys_PageSize AS NVARCHAR)+') FROM ' + @sys_Table + @new_where1  
EXEC SP_EXECUTESQL @SqlCount,N'@RCount INT OUTPUT,@PCount INT OUTPUT',  
               @RCount OUTPUT,@PCount OUTPUT  
IF @sys_PageIndex > CEILING((@RCount+0.0)/@sys_PageSize)    --如果输入的当前页数大于实际总页数,则把实际总页数赋值给当前页数  
BEGIN  
    SET @sys_PageIndex =  CEILING((@RCount+0.0)/@sys_PageSize)  
END  
set @sql = 'select '+ @sys_fields +' from ' + @sys_Table + ' w1 '  
    + ' where '+ @sys_Key +' in ('  
        +'select top '+ ltrim(str(@sys_PageSize)) +' ' + @sys_Key + ' from '  
        +'('  
            +'select top ' + ltrim(STR(@sys_PageSize * @sys_PageIndex + @sys_Begin)) + ' ' + @sys_Key + ' FROM '  
        + @sys_Table + @new_where1 + @new_order2   
        +') w ' + @new_order1  
    +') ' + @new_order2  
print(@sql)  
Exec(@sql)  

GO

-- ----------------------------
-- Indexes structure for table Sys_Action
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Action
-- ----------------------------
ALTER TABLE [dbo].[Sys_Action] ADD PRIMARY KEY ([Action_Id])
GO

-- ----------------------------
-- Indexes structure for table Sys_Department
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Department
-- ----------------------------
ALTER TABLE [dbo].[Sys_Department] ADD PRIMARY KEY ([Department_Id])
GO

-- ----------------------------
-- Indexes structure for table Sys_Menu
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Menu
-- ----------------------------
ALTER TABLE [dbo].[Sys_Menu] ADD PRIMARY KEY ([Menu_Id])
GO

-- ----------------------------
-- Indexes structure for table Sys_Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Role
-- ----------------------------
ALTER TABLE [dbo].[Sys_Role] ADD PRIMARY KEY ([Role_Id])
GO

-- ----------------------------
-- Indexes structure for table Sys_Role_Action
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Role_Action
-- ----------------------------
ALTER TABLE [dbo].[Sys_Role_Action] ADD PRIMARY KEY ([Role_Id], [Action_Id])
GO

-- ----------------------------
-- Indexes structure for table Sys_Role_Menu
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Role_Menu
-- ----------------------------
ALTER TABLE [dbo].[Sys_Role_Menu] ADD PRIMARY KEY ([Menu_Id], [Role_Id])
GO

-- ----------------------------
-- Indexes structure for table sys_sequence
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table sys_sequence
-- ----------------------------
ALTER TABLE [dbo].[sys_sequence] ADD PRIMARY KEY ([SEQ_ID])
GO

-- ----------------------------
-- Indexes structure for table Sys_Setting
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Setting
-- ----------------------------
ALTER TABLE [dbo].[Sys_Setting] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table Sys_Sigin_log
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Sigin_log
-- ----------------------------
ALTER TABLE [dbo].[Sys_Sigin_log] ADD PRIMARY KEY ([LINE_ID])
GO

-- ----------------------------
-- Indexes structure for table Sys_User
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_User
-- ----------------------------
ALTER TABLE [dbo].[Sys_User] ADD PRIMARY KEY ([User_Id])
GO

-- ----------------------------
-- Indexes structure for table Sys_User_Department
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_User_Department
-- ----------------------------
ALTER TABLE [dbo].[Sys_User_Department] ADD PRIMARY KEY ([User_id], [Department_id])
GO

-- ----------------------------
-- Indexes structure for table Sys_User_Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_User_Role
-- ----------------------------
ALTER TABLE [dbo].[Sys_User_Role] ADD PRIMARY KEY ([User_Id], [Role_Id])
GO
