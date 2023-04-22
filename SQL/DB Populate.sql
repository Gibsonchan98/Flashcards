
INSERT into FLASHCARDS (Question, Answer, Correct) VALUES ('What is 1 + 1?', '2', 0)
INSERT into FLASHCARDS (Question, Answer, Correct) VALUES ('What is 1 + 3?', '4', 0)


SELECT * FROM FLASHCARDS
SELECT * FROM FLASHCARDS WHERE ID = 1

UPDATE FLASHCARDS SET Question = 'What is 1 + 2', Answer = '3', Correct = 0 WHERE ID = 1

DELETE FROM FLASHCARDS WHERE ID = 1