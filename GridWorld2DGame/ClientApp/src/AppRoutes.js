import { Home } from "./components/Home";

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
