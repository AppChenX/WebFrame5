

/*
自定义绑定

*/
(function ($, ko) {

    var jqElement = function (element) {
        var jq = $(element);
        if ($(document).find(element).length == 0) {  //处理元素在父页面执行的情况
            if ($(parent.document).find(element).length > 0)
                jq = parent.$(element);
        }
        return jq;
        };
    ko.creatEasyuiValueBindings = function (o) {
        o = $.extend({ type: '', event: '', getter: 'getValue', setter: 'setValue', fix: $.noop, formatter: function (v) { return v; } }, o);

        var customBinding = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var jq = jqElement(element);
               // $.parser.parse(jq);  
                var handler = jq[o.type]('options')[o.event];
                var opt = {};

                //handle the field changing
                opt[o.event] = function () {
                    handler.apply(element, arguments);
                    var value = jq[o.type](o.getter);
                    if (valueAccessor() == null) throw "viewModel中没有页面绑定的字段";
                    valueAccessor()(value);
                };

                //handle disposal (if KO removes by the template binding)
                ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                    jq[o.type]("destroy");
                });

                o.fix(element, valueAccessor);
                jq[o.type](opt);
            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                value = ko.utils.unwrapObservable(valueAccessor());
                jqElement(element)[o.type](o.setter, o.formatter(value));
            }
        };
        ko.bindingHandlers[o.type + '_value'] = customBinding;
    };

    //绑定样式xx-value: value
    ko.creatEasyuiValueBindings({ type: 'combobox', event: 'onSelect' });
    ko.creatEasyuiValueBindings({ type: 'combotree', event: 'onChange' });
    ko.creatEasyuiValueBindings({ type: 'datebox', event: 'onSelect', formatter: CH.utils.yyymmdd }); 
    ko.creatEasyuiValueBindings({ type: 'numberbox', event: 'onChange' });
    ko.creatEasyuiValueBindings({ type: 'textbox', event: 'onChange' });
    ko.creatEasyuiValueBindings({ type: 'numberspinner', event: 'onChange', fix: function (element) { $(element).width($(element).width() + 20); } });

    /*
    */
    ko.creatEasyuiGridBindings = function (gridType) {
         
        var gridBinding =
            {
                update: function (element, valueAccessor, allBindingsAccessor, viewModel)
                {
                   
                    //var gridType='datagrid'

                    var grid = jqElement(element);

                    var opts = ko.toJS(valueAccessor());//转换绑定的数据为js; 

                    opts = $.extend({
                        rownumbers: true,
                        collapsible: false, 
                        pagination: true, //表示在datagrid设置分页
                        singleSelect: true,
                        pageSize: CH.seetings.pageSize, 
                        pageList: [10, 20, 30, 40, 50],
                        method: 'get',
                        border: false 
                        //onClickRow: editGrid.begin,
                        //onDblClickRow: editGrid.ended
                    }, opts); 
                    grid[gridType](opts);
                  
                  
                    //添加gridType属性 
                   valueAccessor()[gridType] = function () { return grid[gridType].apply(grid, arguments); }
                    //添加$element属性 
                   valueAccessor()['$element'] = function () { return grid; };

                }
            };

        return gridBinding;
    };

    ko.bindingHandlers.datagrid = ko.creatEasyuiGridBindings('datagrid');
    ko.bindingHandlers.treegrid = ko.creatEasyuiGridBindings('treegrid');


    //
    ko.creatZtreeBindings = function () {

        var ztreeBindings = {

            update: function (element, valueAccessor, allBindingsAccessor, viewModel) {

                var ztree =jqElement(element);

                var opts = ko.toJS(valueAccessor());
                 
                var zNodes = opts.zNodes || {};
                //通过url获取zNodes;
                if (opts.url && !opts.zNodes)
                {
                    //加载数据
                    $.ajax({
                        type: opts.method||'get',
                        url: opts.url, //
                        dataType: 'json',
                        data:opts.data||{},
                        contentType: 'application/json',
                        success: function (d) { 
                            if(d)
                            {
                                zNodes = d;
                                $.fn.zTree.init(ztree, opts.setting, zNodes);
                                var zTree = $.fn.zTree.getZTreeObj(ztree.attr('id') || "");

                                valueAccessor()["zTree"] = zTree;
                                if (opts.expandAll)
                                {
                                  
                                    zTree.expandAll(true);
                                }
                            }  
                        }
                    });
                }

               
            }
        };


        return ztreeBindings;
    };  

    //绑定ztree
    ko.bindingHandlers.ztree = ko.creatZtreeBindings();




    //初始化控件
    ko.createEasyuiInitBindings = function (o) {
        o = $.extend({ type: '' }, o);
        var customBinding = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var jq = jqElement(element), opt = ko.mapping.toJS(valueAccessor());
                var handler = function () {
                    jq[o.type](opt);
                };
                jq[o.type] ? handler() : using(o.type, handler);

                //handle disposal (if KO removes by the template binding)
                ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                    jq[o.type]("destroy");
                });
                valueAccessor()["$element"] = function () { return jq };
            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var jq = jqElement(element), opt = ko.mapping.toJS(valueAccessor());
                if (jq[o.type]) jq[o.type](opt);
            }
        };
        var bindName = 'easyui' + o.type.replace(/(^|\s+)\w/g, function (s) { return s.toUpperCase(); });
        ko.bindingHandlers[bindName] = customBinding;
    };

    ko.createEasyuiInitBindings({ type: 'tabs' });
    ko.createEasyuiInitBindings({ type: 'tree' });
    ko.createEasyuiInitBindings({ type: 'combotree' });
    ko.createEasyuiInitBindings({ type: 'combobox' });
    ko.createEasyuiInitBindings({ type: 'linkbutton' });

})(jQuery,ko);