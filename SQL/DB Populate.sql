INSERT into FLASHCARDS (Question, Answer, Correct, Category) VALUES ('What is 1 + 1?', '2', 0, 'Math')
INSERT into FLASHCARDS (Question, Answer, Correct, Category) VALUES ('What is 1 + 3?', '4', 0, 'Math')


SELECT * FROM FLASHCARDS
SELECT * FROM FLASHCARDS WHERE ID = 1

UPDATE FLASHCARDS SET Question = 'What is 1 + 2', Answer = '3', Correct = 0, Category = 'Math' WHERE ID = 1

DELETE FROM FLASHCARDS WHERE ID = 1