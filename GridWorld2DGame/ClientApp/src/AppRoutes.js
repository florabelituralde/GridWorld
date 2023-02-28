import { Home } from "./components/Home";
import { BoardGame } from "./components/BoardGame";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/board-game',
    element: <BoardGame />
  }
];

export default AppRoutes;
