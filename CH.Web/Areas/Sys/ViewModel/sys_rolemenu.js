var viewModle_bz = viewModle_bz || {};

/*

 用户角色管理
*/
viewModle_bz.sys_rolemenu = function (row,userId) {


    var that = this;

    this.submit = function (dialog) {



        var nodes = that.tree.zTree.getCheckedNodes();
        if (nodes) { 
            //调用api执行对应的按钮权限
            $.ajax({
                type: 'post',
                url: '/api/sys/SysMenuApi/EditMenuRole/' + row.RoleId,
                dataType: 'json',
                data: JSON.stringify(nodes),
                contentType: 'application/json',
                success: function (d) {

                    if (d) {
                        if (!d.status) {

                            parent.$.messager.alert("错误", d.msg, 'error');
                        }
                        else {
                            dialog.dialog('close');
                        }
                    }
                }
            });
        } 
    };

    this.tree = {
        expandAll:true,
        url: '/api/sys/SysMenuApi/PostMenuExByUserId',
        method: 'post',
        data: JSON.stringify({ uid: userId, rid: row.RoleId }),
        setting: {
            view: {
                selectedMulti: false
            },
            check: {
                enable: true 
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "id",
                    pIdKey: "pId",
                    rootPId: "",
                    iconCls: 'iconCls'

                }
            } 
        }
        
    };
 
};

