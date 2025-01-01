-- モジュールテーブルを作成
local helpers = {}

-- t 関数を定義
helpers.t = function(message)
    talk(message)
end

-- o 関数を定義
helpers.o = function(options)
    return option(options)
end

-- モジュールを返す
return helpers