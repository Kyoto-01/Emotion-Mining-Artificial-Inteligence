# Emotion-Mining-Artificial-Inteligence
This program is an artificial intelligence that mines texts in search of emotions that can be positive, negative or neutral. 

<h2>Natural Language Processing</h2>
In this softwre, the input text is pocessed by the PNL.dll methods. The text goes through the process of removing accents, punctuation, stopwords and also through the stemming process until a list of its most significant tokens is created.

<h2>Machine Learning</h2>
In this step, the tokens are added or updated in the database and the Naive Bayes algorithm is made according to the positive and negative quantity of each token. Naive Bayes assigns the positive and negative probability of each token and these probabilities are also saved in the database.

<h2>Test</h2>
the test does the PLN process in the text and looks for positive probabilities, adding them to the positive variable, and negative ones, adding them to the negative variable. After the search, the value of the variables is compared, attributing the emotion contained in the text.
