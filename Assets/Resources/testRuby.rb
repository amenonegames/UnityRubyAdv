def debug(message)
    cmd :debug, message:
end

def t(message)
    cmd :talk, message:
end

def o(opMessage)
    cmd :option, options: opMessage
end

class DialogueManager
    def initialize
      @nodes = {}
      @state = state
    end
  
    def add_node(name, &block)
      @nodes[name] = block
    end
  
    def jump_to(name)
      if @nodes[name]
        @nodes[name].call
      else
        puts "Node #{name} not found!"
      end
    end
  
    def set_state(key, value)
        @state[key] = value
    end

    def get_state(key)
    @state[key]
    end

    # 判定用メソッドを改良
    def is_state?(key, value)
        @state[key]&.is?(value) # nilガードを追加
    end

  end
  
  # ダイアログの定義
  manager = DialogueManager.new
  
  manager.add_node(:start) do
    t "Start: Please press continue button"
    manager.jump_to(:option)
  end
  
  manager.add_node(:option) do
    o ["Yes", "No"]
    result = manager.is_state?(:result, "Yes")  #異常動作
    result = state[:result].is?("Yes") #正常動作
    if result #=> true
        manager.jump_to(:yes_response)
    else 
        manager.jump_to(:no_response)
    end
  end
  
  manager.add_node(:yes_response) do
    t "Yes? Really?"
    manager.jump_to(:end)
  end

  manager.add_node(:no_response) do
    t "No? Really?"
    manager.jump_to(:end)
  end
  
  manager.add_node(:end) do
    t "End of the dialogue."
  end
  
  # ダイアログの開始
  manager.jump_to(:start)
  