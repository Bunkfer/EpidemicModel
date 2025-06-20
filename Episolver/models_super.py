from typing import Protocol

class Main_model(Protocol):       

    def solve(self)-> None: ...

class Main_graph(Protocol):

    def show_model(self)-> None: ...

    def modelvsSim(self)-> None: ...