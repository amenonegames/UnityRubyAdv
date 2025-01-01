
local DialogueManager = {}

DialogueManager.nodes = {}
DialogueManager.startNode = "start"

function DialogueManager:addNode(nodeName , func)
   self.nodes[nodeName] = func
end

function DialogueManager:jump(nodeName)
    if self.nodes[nodeName] then
        self.nodes[nodeName]() -- 関数を呼び出す
    else
        print("Node not found!")
    end
end

function DialogueManager:start()
    self:jump(self.startNode)
end

function DialogueManager:setStartNode(nodeName)
    self.startNode = nodeName
end

return DialogueManager