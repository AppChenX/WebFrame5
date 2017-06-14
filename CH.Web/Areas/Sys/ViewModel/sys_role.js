
var viewModle_bz = viewModle_bz || {};

viewModle_bz.sys_role = function (userId) {


    console.log('userId:'+userId);
    var that = this;

    this.queryParams = {};


    this.formatterButton = function (value, row,index) {

        //'<a href="#" onclick="setPermissionMenu(\'11111\')">' 
        //var rs = '<a href="#" onclick="setPermissionMenu(' + JSON.stringify(row) + ',\'' + userId + '\')"><span class="icon icon-set2">&nbsp;</span>[菜单权限]</a> '

       // '<a href="#" onclick="setPermissionMenu(' + JSON.stringify(row) + ',\' + userId + \')"><span class="icon icon-set2">&nbsp;</span>[菜单权限]</a> '

      //  var rs = '<a href="#" onclick="setPermissionMenu(\'' + index + '\',\'' + userId + '\')"><span class="icon icon-set2">&nbsp;</span>[菜单权限]</a> '

      //console.log(rs);
        //return rs;

        return '<a href="#" onclick="sys_role_setPermissionMenu(\'' + index + '\',\'' + userId + '\')"><span class="icon icon-set2">&nbsp;</span>[菜单权限]</a><a href="#" onclick="sys_role_setPermissionAction(\'' + index + '\',\'' + userId + '\')"><span class="icon icon-set2">&nbsp;</span>[菜单按钮权限]</a><a href="#" onclick="sys_role_setUser(\'' + index + '\',\'' + userId + '\')"><span class="icon icon-group_edit">&nbsp;</span>[用户管理]</a><a href="#" onclick="sys_role_setRoleOwner(\'' + index + '\',\'' + userId + '\')"><span class="icon icon-group_edit">&nbsp;</span>[角色所有者]</a>';
    };


    this.grid = {
        title: "角色管理",
        rownumbers: true,
        pagination: false,
        idField: 'RoleId',
        border: false,
        striped: true,
        sortName: 'RoleId',
        collapsible: false,
        method: 'get',
        url: '/Api/Sys/SysRoleApi/GetRoleByUserId/' + userId, //获取登录用户下的角色的所有角色
        queryParams: ko.observable(),
        columns: [[{
            field: 'RoleId',
            title: '角色ID',
            algin: 'center',
            sortable: true,
            editor: {
                type: 'validatebox',
                options: {
                    required: 'true',
                    validType: ["length[1,20]"]
                }
            }
        }, {
            field: 'RoleName',
            title: '角色名称',
            align: 'center',
            editor: {
                type: 'validatebox',
                options: {
                    required: 'true',
                    validType: ["length[1,20]"]
                }
            }
        },
        {
            field: 'RoleDesc',
            title: '角色描述',
            align: 'center',
            editor: {
                type: 'validatebox',
                options: {
                    required: 'false',
                    validType: ["length[0,200]"]
                }
            }
        },

        {
            title: '操作',
            field: 'button',
            width: 360,
            formatter: that.formatterButton
        } 
        ]],
        singleSelect: true,
        pageSize: 10,
        pageNumber: 1
    };


    this.gridEdit = new CH.utils.editGridViewModel(that.grid);
    this.grid.onDblClickRow = that.gridEdit.begin;
    this.grid.onClickRow = that.gridEdit.ended;

    this.search = function () {

        that.grid.queryParams(ko.toJS(that.queryParams));
    };
    this.undo = function () {
        this.gridEdit.reject();
    };
    this.add = function () {
        this.gridEdit.addnew({});
    }
    this.save = function () {
        this.gridEdit.save({ url: '/api/sys/SysRoleApi/EditRole' });
    };
    this.edit = function () {

        var row = that.grid.datagrid('getSelected');
        if (!row) return parent.$.messager.alert("提示", '请选择要编辑的数据', 'warning');
        that.gridEdit.begin();

    };
    this.del = function () {
        var row = that.grid.datagrid('getSelected');
        if (!row) return parent.$.messager.alert("提示", '请选择要删除的数据', 'warning');
        that.gridEdit.deleterow();
    };
    //this.queryParams.userId("");
    //this.queryParams.userName("");
    }; 
//ko.applyBindings(new viewModle_bz.sys_role());

var sys_role_setPermissionMenu = function (index, userId) {


    var row = m_sys_role.grid.datagrid('getRows')[index]; 
    

    var dialog= CH.utils.dialog({
        title: "&nbsp;菜单权限管理",
        iconCls: 'icon-key',
        width: 500,
        height: 400,
        html: "#menuroleedit-template",
        submit: function () { 

            var viewModel = dialog.model;
            viewModel.submit(dialog);


        },
        viewModel: function (w) { 

            var that = new viewModle_bz.sys_rolemenu(row,userId); 

            return that;
            //var that = new viewModle_bz.sys_action(menuid);
            //return that;
        }
    });
};
//菜单按钮权限
var sys_role_setPermissionAction = function (index, userId) {
    var row = m_sys_role.grid.datagrid('getRows')[index];
  var  dialog = CH.utils.dialog({
        title: "&nbsp;按钮权限管理",
        iconCls: 'icon-key',
        width: 500,
        height: 400,
        html: "#actionroleedit-template",
        submit: function () {
           
             
            var viewModel = dialog.model;
            viewModel.submit(dialog);


        },
        viewModel: function (w) {

            var that = new viewModle_bz.sys_roleaction(row, userId);
            return that;
           
        }
    });
};

var sys_role_setUser = function (index, userId) {
    var row = m_sys_role.grid.datagrid('getRows')[index];
   var dialog=  CH.utils.dialog({
        title: "&nbsp;用户权限管理",
        iconCls: 'icon-key',
        width: 500,
        height: 400,
        html: "#userroleedit-template",
        buttons :[{
            text: '增加',
            iconCls: 'icon-group-add',
            handler: function () {
                
                var viewModel = dialog.model;
                viewModel.addUser(viewModel);
                
            }
        },
        {
            text: '保存',
            iconCls: 'icon-save',
            handler: function () {

                //var viewModel = dialog.dialog('options').viewModel;
                //viewModel.saveUser();
                var viewModel = dialog.model;
                viewModel.saveUser(dialog);
            }
        }, {
            text: '关闭',
            iconCls: 'icon-cancel',
            handler: function () {

                dialog.dialog('close');
            }

        }
        ],
        viewModel: function (w) { 
             
            //绑定ko
            var that = new viewModle_bz.sys_roleuser(row, userId);
            return that;
        }
   }); 
};

//

var sys_role_setRoleOwner = function (index, userId) {
    var row = m_sys_role.grid.datagrid('getRows')[index];
    var dialog = CH.utils.dialog({
        title: "&nbsp;角色所属管理",
        iconCls: 'icon-key',
        width: 500,
        height: 300,
        html: "#roleedit-roleowner-template",
        buttons: [{
            text: '选择',
            iconCls: 'icon-group-add',
            handler: function () {

                var viewModel = dialog.model;
                viewModel.selectRole(viewModel);

            }
        },
        {
            text: '保存',
            iconCls: 'icon-save',
            handler: function () {
                 
                var viewModel = dialog.model;
                viewModel.submit(dialog); //保存角色所属者
            }
        }, {
            text: '关闭',
            iconCls: 'icon-cancel',
            handler: function () {

                dialog.dialog('close');
            }

        }
        ],
        viewModel: function (w) {

            //绑定ko
            var that = new viewModle_bz.sys_role_member(row, userId);
            return that;
        }
    });
};