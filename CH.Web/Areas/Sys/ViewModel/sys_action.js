var viewModle_bz = viewModle_bz || {};

viewModle_bz.sys_action = function (mid,userId) {

    var that = this;
    var jquery = parent.$;
     this.queryParams = {  };

    this.grid = {
        title: "菜单按钮管理",
        rownumbers: true,
        idField: 'ActionId',
        border: false,
        striped: true,
        sortName: 'ActionId',
        pagination:false,
        collapsible: false,
        method: 'get',
        url: '/Api/Sys/SysActionApi/GetSysAction/'+mid,
        queryParams: ko.observable(),
        columns: [[{
            field: 'ActionId',
            title: '按钮ID',
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
            field: 'MenuId',
            title: '菜单ID',
            align: 'center',
            editor: {
                type: 'validatebox',
                options: {
                    required: 'true',
                    validType: ["length[1,20]"]
                }
            }
        }, {
            field: 'ActionName',
            title: '按钮名称',
            align: 'center',
            editor: {
                type: 'validatebox',
                options: {
                    required: 'true',
                    validType: ["length[1,20]"]
                }
            }
        }, {
            field: 'ActionUrl',
            title: '按钮请求地址',
            align: 'center',
            editor: {
                type: 'validatebox',
                options: {
                    required: 'true'
                }
            }
        }, {
            field: 'ActionIconclass',
            title: '按钮Icons',
            align: 'center', 
            editor: {
                type: 'textbox' 
            }
        }, {
            field: 'ActionBid',
            title: '按钮ID',
            align: 'center',
            editor: {
                type: 'textbox'
            }
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
        this.gridEdit.save({ url: '/Api/Sys/SysActionApi/EditAction/' + mid });
    };
    this.edit = function () {

        var row = that.grid.datagrid('getSelected');
        if (!row) return jquery.messager.alert("提示", '请选择要编辑的数据', 'warning');
        that.gridEdit.begin();

    };
    this.del = function () {
        var row = that.grid.datagrid('getSelected');
        if (!row) return jquery.messager.alert("提示", '请选择要删除的数据', 'warning');
        that.gridEdit.deleterow();
    };
  

   
};



 