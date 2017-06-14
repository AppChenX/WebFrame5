/**
 * @author {CaoGuangHui}

 扩展Tabs 使用Id关联唯一
 */
$.extend($.fn.tabs.methods, {
    //getTabById: function (jq, id) {
    //    var tabs = $.data(jq[0], 'tabs').tabs;
    //    for (var i = 0; i < tabs.length; i++) {
    //        var tab = tabs[i];
    //        if (tab.panel('options').id == id) {
    //            return tab;
    //        }
    //    }
    //    return null;
    //},
    //selectById: function (jq, id) {
    //    return jq.each(function () {
    //        var state = $.data(this, 'tabs');
    //        var opts = state.options;
    //        var tabs = state.tabs;
    //        var selectHis = state.selectHis;
    //        if (tabs.length == 0) { return; }
    //        var panel = $(this).tabs('getTabById', id); // get the panel to be activated 
    //        if (!panel) { return }
    //        var selected = $(this).tabs('getSelected');
    //        if (selected) {
    //            if (panel[0] == selected[0]) { return }
    //            $(this).tabs('unselect', $(this).tabs('getTabIndex', selected));
    //            if (!selected.panel('options').closed) { return }
    //        }
    //        panel.panel('open');
    //        var title = panel.panel('options').title;        // the panel title 
    //        selectHis.push(title);        // push select history 
    //        var tab = panel.panel('options').tab;        // get the tab object 
    //        tab.addClass('tabs-selected');
    //        // scroll the tab to center position if required. 
    //        var wrap = $(this).find('>div.tabs-header>div.tabs-wrap');
    //        var left = tab.position().left;
    //        var right = left + tab.outerWidth();
    //        if (left < 0 || right > wrap.width()) {
    //            var deltaX = left - (wrap.width() - tab.width()) / 2;
    //            $(this).tabs('scrollBy', deltaX);
    //        } else {
    //            $(this).tabs('scrollBy', 0);
    //        }
    //        $(this).tabs('resize');
    //        opts.onSelect.call(this, title, $(this).tabs('getTabIndex', panel));
    //    });
    //},
    //existsById: function (jq, id) {
    //    return $(jq[0]).tabs('getTabById', id) != null;
    //},

    /**
    * 加载iframe内容  
    * @param  {jq Object} jq     [description]  
    * @param  {Object} params    params.which:tab的标题或者index;params.iframe:iframe的相关参数  
    * @return {jq Object}        [description]  
    */
    loadTabIframe: function (jq, params) {
        return jq.each(function () {
            var $tab = $(this).tabs('getTab', params.which);
            if ($tab == null) return;

            var $tabBody = $tab.panel('body');

            //销毁已有的iframe   
            var $frame = $('iframe', $tabBody);
            if ($frame.length > 0) {
                try {//跨域会拒绝访问，这里处理掉该异常   
                    $frame[0].contentWindow.document.write('');
                    $frame[0].contentWindow.close();
                } catch (e) {
                    //Do nothing   
                }
                $frame.remove();
                try
                {
                    if ($.browser.msie) {
                        CollectGarbage();
                    }
                }
                catch(e)
                {

                }

                
            }
            $tabBody.html('');

            $tabBody.css({ 'overflow': 'hidden', 'position': 'relative' });
            var $mask = $('<div style="position:absolute;z-index:2;width:100%;height:100%;background:#ccc;z-index:1000;opacity:0.3;filter:alpha(opacity=30);"><div>').appendTo($tabBody);
            var $maskMessage = $('<div class="mask-message" style="z-index:3;width:auto;height:16px;line-height:16px;position:absolute;top:50%;left:50%;margin-top:-20px;margin-left:-92px;border:2px solid #d4d4d4;padding: 12px 5px 10px 30px;background: #ffffff url(\'/Scripts/easyui/themes/default/images/loading.gif\') no-repeat scroll 5px center;">' + (params.iframe.message || 'Processing, please wait ...') + '</div>').appendTo($tabBody);
            var $containterMask = $('<div style="position:absolute;width:100%;height:100%;z-index:1;background:#fff;"></div>').appendTo($tabBody);
            var $containter = $('<div style="position:absolute;width:100%;height:100%;z-index:0;"></div>').appendTo($tabBody);

            var iframe = document.createElement("iframe");
            iframe.src = params.iframe.src;
            iframe.frameBorder = params.iframe.frameBorder || 0;
            iframe.height = params.iframe.height || '100%';
            iframe.width = params.iframe.width || '100%';
            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    $([$mask[0], $maskMessage[0]]).fadeOut(params.iframe.delay || 'slow', function () {
                        $(this).remove();
                        if ($(this).hasClass('mask-message')) {
                            $containterMask.fadeOut(params.iframe.delay || 'slow', function () {
                                $(this).remove();
                            });
                        }
                    });
                });
            } else {
                iframe.onload = function () {
                    $([$mask[0], $maskMessage[0]]).fadeOut(params.iframe.delay || 'slow', function () {
                        $(this).remove();
                        if ($(this).hasClass('mask-message')) {
                            $containterMask.fadeOut(params.iframe.delay || 'slow', function () {
                                $(this).remove();
                            });
                        }
                    });
                };
            }
            $containter[0].appendChild(iframe);
        });
    },
    /**
     * 增加iframe模式的标签页  
     * @param {[type]} jq     [description]  
     * @param {[type]} params [description]  
     */
    addIframeTab: function (jq, params) {
        return jq.each(function () {
            if (params.tab.href) {
                delete params.tab.href;
            }
            $(this).tabs('add', params.tab);
            $(this).tabs('loadTabIframe', { 'which': params.tab.id, 'iframe': params.iframe });
        });
    },
    /**
     * 更新tab的iframe内容  
     * @param  {jq Object} jq     [description]  
     * @param  {Object} params [description]  
     * @return {jq Object}        [description]  
     */
    updateIframeTab: function (jq, params) {
        return jq.each(function () {
            params.iframe = params.iframe || {};
            if (!params.iframe.src) {
                var $tab = $(this).tabs('getTab', params.which);
                if ($tab == null) return;
                var $tabBody = $tab.panel('body');
                var $iframe = $tabBody.find('iframe');
                if ($iframe.length === 0) return;
                $.extend(params.iframe, { 'src': $iframe.attr('src') });
            }
            $(this).tabs('loadTabIframe', params);
        });
    }

});