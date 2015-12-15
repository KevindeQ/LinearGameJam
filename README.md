#Minions in Algebra Space
##Introduction 
Balance is everything, where there is ying, there should also be yang. The same applies to Minions and bananas. However the archenemy of Minions has attacked the Banana republic and kidnapped the one and only Banana King.
It all comes down to one Minion, Mippi, to save the Banana King from the cruel DeathCube using his linear algebra skills.

###Normal level
During this level, there are three matrices: pre, result and post. The initial value of the pre and post matrices is an identity matrix. In the game, matrices are represented as a grid of towers. The height of eacht tower represent the value in the matrix. The player starts on the start block on the result matrix and needs to find the way to the spaceship to defeat the DeathCube boss for the glory of the Banana republic. 

The player has to use matrix multiplication to reach the spaceship, for example changing the pre and/or post matrices by adding or removing blocks will change the value of the result matrix. The minion can move to the left, right, up, down and jump up to one block difference between the current and the next block on the result matrix, this does not apply for the pre and post matrices. Additionally the minion can pick up a banana item which increases the jump difference to two. After finding the spaceship, the player will be teleported to the next level.

###Boss level
After a number of normal levels, the player will reach the boss level. The boss is made out of blocks and multiple blocks are colored, one of these block is colored differently, this is the initial block. The player has to shoot the initial block. After shooting the initial block, a vector appears on the top left part of the screen. Using this vector, the player has to find the right translated coordinate (block) counting from the last shot block. If a wrong block is shot, then the game is over. 
