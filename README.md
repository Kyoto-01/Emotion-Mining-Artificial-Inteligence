# Emotion-Mining-Artificial-Inteligence
This program is an artificial intelligence that mines texts in search of emotions that can be positive, negative or neutral. 

<h2>Natural Language Processing</h2>
In this softwre, the input text is pocessed by the PNL.dll methods. The text goes through the process of removing accents, punctuation, stopwords and also through the stemming process until a list of its most significant tokens is created.

<h3>Machine Learning</h3>
In this step, the tokens are added or updated in the database and the Naive Bayes algorithm is made according to the positive and negative quantity of each token. Naive Bayes assigns the positive and negative probability of each token and these probabilities are also saved in the database.

<h3>Test</h3>
o teste faz o processo PLN no texto e busca as probabilidades positivas, adicionando-as à variável positiva, e negativas, adicionando-as à variável negativa. Após a busca, o valor das variáveis é comparado, atribuindo a emoção contida no texto.

