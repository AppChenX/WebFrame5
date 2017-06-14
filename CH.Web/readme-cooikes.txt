
http://blog.csdn.net/soul_code/article/details/52768421?ref=myread

主要防止非法用户修改cookie信息，以及cookie的超时时间 
传统cookie存储，Cookie(name, value)，value很容易就被篡改。 
防修改cookie存储，Cookie(name, value+“&&”+ signToken+“&&”+saveTime+“&&”+maxTime) 
signToken ：签名密钥 由md5（value+saveTime+maxTime+”自定义密钥“）生成 
saveTime：cookie创建时间 
maxTime：cookie超时时间

设置Cookie

    public static void put(HttpServletResponse response, String key, String value, int maxTime) {
        String pwdKey = "white_yu"; //自定义密钥
        String saveTime = System.currentTimeMillis() + "";
        String signToken = md5(pwdKey, saveTime, maxTime + "", value);

        String cookieValue = signToken + "&&" + saveTime + "&&" + maxTime
                + "&&" + value;
        Cookie cookie = new Cookie(key,cookieValue);
        cookie.setMaxAge(maxTime);
        response.addCookie(cookie);

    }
1
2
3
4
5
6
7
8
9
10
11
12
获取Cookie

    public static String getCookie(String cookieValue) {
        String pwdKey = "white_yu"; //自定义密钥
        if (StringUtils.isNotBlank(cookieValue)) {
            String cookieStrings[] = cookieValue.split("&&");
            if (null != cookieStrings && 4 == cookieStrings.length) {
                String signToken = cookieStrings[0];
                String saveTime = cookieStrings[1];
                String maxTime = cookieStrings[2];
                String value = cookieStrings[3];

                String sign = md5(pwdKey, saveTime, maxTime, value);

                // 保证 cookie 不被人为修改
                if (sign.equals(signToken)) {
                    long stime = Long.parseLong(saveTime);
                    long maxtime = Long.parseLong(maxTime) * 1000;
                    // 查看是否过时
                    if ((stime + maxtime) - System.currentTimeMillis() > 0) {
                        return value;
                    }
                }
            }
        }
        return null;
    }